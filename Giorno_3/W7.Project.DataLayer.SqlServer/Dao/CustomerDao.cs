using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;
using W7.Project.DataLayer.Dao;
using W7.Project.DataLayer.Dao.Exceptions;
using W7.Project.DataLayer.Entities;
using W7.Project.DataLayer.SqlServer.Exceptions;

namespace W7.Project.DataLayer.SqlServer.Dao
{
    public class CustomerDao : DaoBase, ICustomerDao
    {
        private const int PERSON_ENTITY = 0;
        private const int COMPANY_ENTITY = 1;

        private const string SELECT_CUSTOMER_BY_ID =
            "SELECT cu.Id, " +
            "   cu.Address, cu.City, cu.Region, cu.PostalCode, cu.CustomerType " +
            "FROM Customers cu " +
            "WHERE Id = @id";
        private const string SELECT_COMPANY_BY_ID =
            "SELECT co.Id, " +
            "   co.Name, co.VatCode, " +
            "FROM Companies co " +
            "WHERE Id = @id";
        private const string SELECT_PERSON_BY_ID =
            "SELECT pe.Id, " +
            "   pe.FirstName, pe.LastName, pe.FiscalCode, pe.Title, " +
            "FROM People pe " +
            "WHERE Id = @id";

        private const string SELECT_ALL_COMPANIES =
            "SELECT co.Id, " +
            "   co.Name, co.VatCode, " +
            "   cu.Address, cu.City, cu.Region, cu.PostalCode " +
            "FROM Customers cu JOIN Companies co ON co.Id = cu.Id";
        private const string SELECT_ALL_PEOPLE =
            "SELECT pe.Id, " +
            "   pe.FirstName, pe.LastName, pe.FiscalCode, pe.Title, " +
            "   cu.Address, cu.City, cu.Region, cu.PostalCode " +
            "FROM Customers cu JOIN People pe ON pe.Id = cu.Id";
        private const string INSERT_CUSTOMER =
            "INSERT INTO Customers(Address, City, Region, PostalCode, CustomerType) " +
            "OUTPUT INSERTED.Id " +
            "VALUES(@address, @city, @region, @postalCode, @type)";
        private const string INSERT_COMPANY = "INSERT INTO Companies(Id, Name, VatCode) VALUES(@id, @name, @vatCode)";
        private const string INSERT_PERSON = "INSERT INTO People(Id, FirstName, LastName, Title, FiscalCode) VALUES(@id, @firstName, @lastName, @title, @fiscalCode)";

        public CustomerDao(IConfiguration configuration, ILogger<CustomerDao> logger) : base(configuration, logger) { }

        public IEnumerable<CustomerEntity> GetAll() {
            var result = new List<CustomerEntity>();
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_ALL_PEOPLE, conn)) {
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read()) result.Add(new PersonEntity {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        FiscalCode = reader.GetString(3),
                        Title = reader.IsDBNull(4) ? null : reader.GetString(4),
                        Address = reader.GetString(5),
                        City = reader.GetString(6),
                        Region = reader.IsDBNull(7) ? null : reader.GetString(7),
                        PostalCode = reader.GetString(8),
                        CustomerType = PERSON_ENTITY,
                    });
                }
                using (var cmd = new SqlCommand(SELECT_ALL_COMPANIES, conn)) {
                    using var reader = cmd.ExecuteReader();
                    while (reader.Read()) result.Add(new CompanyEntity {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        VatCode = reader.GetString(2),
                        Address = reader.GetString(3),
                        City = reader.GetString(4),
                        Region = reader.GetString(5),
                        PostalCode = reader.GetString(6),
                        CustomerType = COMPANY_ENTITY,
                    });
                }
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception in {}", nameof(GetAll));
                throw new DaoException(innerException: ex);
            }
            return result.OrderBy(r => r.Id);
        }

        public CustomerEntity GetById(long id) {
            try {
                int customerType = -1;
                string? address;
                string? city;
                string? region;
                string? postalCode;
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using (var cmd = new SqlCommand(SELECT_CUSTOMER_BY_ID, conn)) {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (!reader.Read()) throw new EntityNotFoundException { SearchedKey = id };
                    address = reader.GetString(1);
                    city = reader.GetString(2);
                    region = reader.GetString(3);
                    postalCode = reader.GetString(4);
                    customerType = reader.GetInt32(5);
                }
                if (customerType == PERSON_ENTITY) {
                    using var cmd = new SqlCommand(SELECT_PERSON_BY_ID, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (!reader.Read()) throw new EntityNotFoundException { SearchedKey = id };
                    return
                        new PersonEntity {
                            Address = address,
                            City = city,
                            CustomerType = PERSON_ENTITY,
                            FirstName = reader.GetString(1),
                            FiscalCode = reader.GetString(3),
                            LastName = reader.GetString(2),
                            PostalCode = postalCode,
                            Id = id,
                            Region = region,
                            Title = reader.GetString(4)
                        };
                }
                else if (customerType == COMPANY_ENTITY) {

                    using var cmd = new SqlCommand(SELECT_COMPANY_BY_ID, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    if (!reader.Read()) throw new EntityNotFoundException { SearchedKey = id };
                    return
                        new CompanyEntity {
                            Address = address,
                            City = city,
                            CustomerType = PERSON_ENTITY,
                            Name = reader.GetString(1),
                            VatCode = reader.GetString(2),
                            PostalCode = postalCode,
                            Id = id,
                            Region = region,
                        };
                }
                throw new InvalidCustomerTypeException();
            }
            catch (DaoException ex) {
                logger.LogError(ex, "DAO exception in {}", nameof(GetById));
                throw;
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception in {}", nameof(GetAll));
                throw new DaoException(innerException: ex);
            }
        }

        private int ExecuteInsertCustomerCommand(CustomerEntity c, int type, SqlTransaction transaction) {
            using var cmd = new SqlCommand(INSERT_CUSTOMER, transaction.Connection, transaction);
            cmd.Parameters.AddWithValue("@address", c.Address);
            cmd.Parameters.AddWithValue("@city", c.City);
            cmd.Parameters.AddWithValue("@region", c.Region.Coalesce());
            cmd.Parameters.AddWithValue("@postalCode", c.PostalCode);
            cmd.Parameters.AddWithValue("@type", type);
            return (int)cmd.ExecuteScalar();
        }

        public CustomerEntity Save(CustomerEntity customer) {
            try {
                using var conn = new SqlConnection(connectionString);
                conn.Open();
                using var trans = conn.BeginTransaction();
                int id = 0;
                if (customer is PersonEntity person) {
                    id = ExecuteInsertCustomerCommand(person, PERSON_ENTITY, trans);
                    using var cmd = new SqlCommand(INSERT_PERSON, conn, trans);
                    cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", person.LastName);
                    cmd.Parameters.AddWithValue("@fiscalCode", person.FiscalCode);
                    cmd.Parameters.AddWithValue("@title", person.Title.Coalesce());
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }
                else if (customer is CompanyEntity company) {
                    {
                        id = ExecuteInsertCustomerCommand(company, COMPANY_ENTITY, trans);
                        using var cmd = new SqlCommand(INSERT_COMPANY, conn, trans);
                        cmd.Parameters.AddWithValue("@name", company.Name);
                        cmd.Parameters.AddWithValue("@vatCode", company.VatCode);
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
                return GetById(id);
            }
            catch (Exception ex) {
                logger.LogError(ex, "Exception in {}", nameof(Save));
                throw new DaoException(innerException: ex);
            }
        }
    }
}
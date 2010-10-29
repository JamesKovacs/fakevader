using AutoMapper;
using NUnit.Framework;

namespace FakeVader.Tests {
    [TestFixture]
    public class WhenAutoMappingCustomerToCustomerViewModel {
        [SetUp]
        public void SetUp() {
            Mapper.CreateMap<Customer, CustomerViewModel>();
//                .ForMember(x => x.OfficeStreet, y=>y.MapFrom(z=>z.HomeOffice.Street));
        }

        [Test]
        public void MappingShouldBeValid() {
             Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void ShouldMatchProperties() {
            var customer = new Customer {
                Id = 42,
                Name = "John Smith",
                Home = new Location {
                                        Street = "1 Microsoft Way",
                                        City = "Redmond",
                                        Province = "WA",
                                    },
                Office = new Location {
                                          Street = "2 Microsoft Way",
                                          City = "Redmond",
                                          Province = "WA",
                                      }
            };

            var viewModel = Mapper.Map<Customer, CustomerViewModel>(customer);
//            var existingViewModel = new CustomerViewModel();
//            Mapper.Map(customer, existingViewModel);
            Assert.That(viewModel.Id, Is.EqualTo(customer.Id));
            Assert.That(viewModel.Name, Is.EqualTo(customer.Name));
            Assert.That(viewModel.HomeStreet, Is.EqualTo(customer.Home.Street));
        }
    }

    public class CustomerViewModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HomeStreet { get; set; }
        public string HomeCity { get; set; }
        public string HomeProvince { get; set; }
        public string OfficeStreet { get; set; }
        public string OfficeCity { get; set; }
        public string OfficeProvince { get; set; }
    }

    public interface ICustomerViewModel {
        int Id { get; set; }
        string Name { get; set; }
        string HomeStreet { get; set; }
        string HomeCity { get; set; }
        string HomeProvince { get; set; }
        string OfficeStreet { get; set; }
        string OfficeCity { get; set; }
        string OfficeProvince { get; set; }
    }

    public class Customer {
        public int Id { get; set; }
        public string Name { get; set; }
        public Location Home { get; set; }
        public Location Office { get; set; }
    }

    public class Location {
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }
}
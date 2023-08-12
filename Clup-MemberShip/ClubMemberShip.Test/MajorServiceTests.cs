using ClubMemberShip.Repo.Models;
using ClubMemberShip.Repo.Repository;
using ClubMemberShip.Repo.UnitOfWork;
using ClubMemberShip.Service;
using ClubMemberShip.Service.Service;
using Moq;
using Assert = NUnit.Framework.Assert;

namespace ClubMemberShip.Test;

public class MajorServiceTests
{
    private Mock<IMajorRepo> productRepositoryMock;
    private Mock<IUnitOfWork> unitOfWorkMock;
    private IMajorService sut;

    [SetUp]
    public void Init()
    {
        productRepositoryMock = new Mock<IMajorRepo>();
        unitOfWorkMock = new Mock<IUnitOfWork>();
        sut = new MajorService(unitOfWorkMock.Object);
    }


    [Test]
    public void ProductService_Given_Product_Id_Should_Get_Product_Name()
    {
        //Arrange
        var productId = 999;
        var expected = "AAA";
        var major = new Major() { Name = expected, Id = productId };
        productRepositoryMock.Setup(m => m.GetById(productId)).Returns(major).Verifiable();
        unitOfWorkMock.Setup(m => m.MajorRepo).Returns(productRepositoryMock.Object);

        //Action
        var actual = sut.GetById(productId);
        //Assert
        productRepositoryMock.Verify();
        Assert.IsNotNull(actual);
        Assert.That(actual?.Name, Is.EqualTo(expected));
    }

    [Test]
    public void GetAllMajor_via_service()
    {
        // Arrange
        List<Major> majors = new List<Major>()
        {
            new()
            {
                Code = "Test1",
                Detail = "Test1",
                Id = 1,
                Name = "A Test Major",
                Semeter = 1,
                Status = Status.Active
            },
            new()
            {
                Code = "Test2",
                Detail = "Test2",
                Id = 2,
                Name = "A Test1",
                Semeter = 2,
                Status = Status.Active
            },
        };
        productRepositoryMock.Setup(m => m.GetAll(null, null, "")).Returns(majors).Verifiable();
        unitOfWorkMock.Setup(m => m.MajorRepo).Returns(productRepositoryMock.Object);

        //Action
        var actual = sut.GetAll();

        //Assert
        productRepositoryMock.Verify();
        Assert.IsNotNull(actual);
        Assert.That(actual, Is.EqualTo(majors));
    }

    [TearDown]
    public void Cleanup()
    {
        productRepositoryMock = null!;
        unitOfWorkMock = null!;
        sut = null!;
    }
}
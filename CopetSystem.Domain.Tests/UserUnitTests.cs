using CopetSystem.Domain.Entities;
using CopetSystem.Domain.Validation;
using FluentAssertions;

namespace CopetSystem.Domain.Tests;
public class UserUnitTests
{
    [Fact(DisplayName = "Create User With Valid State")]
    public void CreateUser_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new User("User Name", "username@gmail.com", "123456", "15162901784", "TEST");
        action.Should()
             .NotThrow<CopetSystem.Domain.Validation.DomainExceptionValidation>();
    }

    #region Name Tests
    [Fact]
    public void CreateUser_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new User("Us", "username@gmail.com", "123456", "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.MinLength("name", 3));
    }

    [Fact]
    public void CreateUser_BigNameValue_DomainExceptionBigName()
    {
        Action action = () => new User("frttcgyxukstpasvqpbhqmsbjjvolqsrbfkaiptymddeegoedgodnxtlotplntqitreugkiernzsjmganfdjxcyagoqrzmadqffbsvehnblaovkzclijojbbrustwczcilguchcmrfswjjwquyjbhwgdtnwysdxuymmaibjwvnpvemjxpdkirtjezwyifnrmngoodufstmndqcgawzlvqazxfhdhrtcditryoiczqabbpdhqgwqzukrenvvezlwiciwbprebrxuiytnumvupvoqtdfnbmoxrrgalrudecdugkfblogserwipsrbcqtmotleqarahfqxokfqmrsorjuofatcvsd", "username@gmail.com", "123456", "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.MaxLength("name", 300));
    }

    [Fact]
    public void CreateUser_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new User(string.Empty, "username@gmail.com", "123456", "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("name"));
    }

    [Fact]
    public void CreateUser_WithNullNameValue_DomainExceptionInvalidName()
    {
        Action action = () => new User(null, "username@gmail.com", "123456", "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("name"));
    }

    [Fact]
    public void UpdateUserName_WithValidParameters_ResultObjectValidState()
    {
        var model = new User("User Name", "username@gmail.com", "123456", "15162901784", "TEST");
        Action action = () => model.UpdateName("Teste Name");
        action.Should()
            .NotThrow<CopetSystem.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void UpdateUserName_WithInvalidParameters_ResultObjectValidState()
    {
        var model = new User("User Name", "username@gmail.com", "123456", "15162901784", "TEST");
        Action action = () => model.UpdateName(string.Empty);
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("name"));
    }
    #endregion

    #region Email Tests
    [Fact]
    public void CreateUser_MissingEmailValue_DomainExceptionRequiredEmail()
    {
        Action action = () => new User("User Name", string.Empty, "123456", "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("email"));
    }

    [Fact]
    public void CreateUser_BigEmailValue_DomainExceptionBigEmail()
    {
        Action action = () => new User("User Name", "frttcgyxukstpasvqpbhqmsbjjvolqsrbfkaiptymddeegoedgodnxtlotplntqitreugkiernzsjmganfdjxcyagoqrzmadqffbsvehnblaovkzclijojbbrustwczcilguchcmrfswjjwquyjbhwgdtnwysdxuymmaibjwvnpvemjxpdkirtjezwyifnrmngoodufstmndqcgawzlvqazxfhdhrtcditryoiczqabbpdhqgwqzukrenvvezlwiciwbprebrxuiytnumvupvoqtdfnbmoxrrgalrudecdugkfblogserwipsrbcqtmotleqarahfqxokfqmrsorjuofatcvsd", "123456", "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.MaxLength("email", 300));
    }

    [Fact]
    public void CreateUser_WithNullEmailValue_DomainExceptionRequiredEmail()
    {
        Action action = () => new User("User Name", null, "123456", "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("email"));
    }

    [Fact]
    public void CreateUser_WithInvalidEmailValue_DomainExceptionInvalidEmail()
    {
        Action action = () => new User("User Name", "aaaa-bbbb", "123456", "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.InvalidEmail("email"));
    }
    #endregion

    #region Password Tests
    [Fact]
    public void CreateUser_ShortPasswordValue_DomainExceptionShortPassword()
    {
        Action action = () => new User("User Name", "username@gmail.com", "123", "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.MinLength("password", 6));
    }

    [Fact]
    public void CreateUser_BigPasswordValue_DomainExceptionBigPassword()
    {
        Action action = () => new User("User Name", "username@gmail.com", "frttcgyxukstpasvqpbhqmsbjjvolqsrbfkaiptymddeegoedgodnxtlotplntqitreugkiernzsjmganfdjxcyagoqrzmadqffbsvehnblaovkzclijojbbrustwczcilguchcmrfswjjwquyjbhwgdtnwysdxuymmaibjwvnpvemjxpdkirtjezwyifnrmngoodufstmndqcgawzlvqazxfhdhrtcditryoiczqabbpdhqgwqzukrenvvezlwiciwbprebrxuiytnumvupvoqtdfnbmoxrrgalrudecdugkfblogserwipsrbcqtmotleqarahfqxokfqmrsorjuofatcvsd", "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.MaxLength("password", 300));
    }

    [Fact]
    public void CreateUser_MissingPasswordValue_DomainExceptionRequiredPassword()
    {
        Action action = () => new User("User Name", "username@gmail.com", string.Empty, "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("password"));
    }

    [Fact]
    public void CreateUser_WithNullPasswordValue_DomainExceptionInvalidPassword()
    {
        Action action = () => new User("User Name", "username@gmail.com", null, "15162901784", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("password"));
    }

    [Fact]
    public void UpdateUserPassword_WithValidParameters_ResultObjectValidState()
    {
        var model = new User("User Name", "username@gmail.com", "123456", "15162901784", "TEST");
        Action action = () => model.UpdatePassword("987654321");
        action.Should()
            .NotThrow<CopetSystem.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void UpdateUserPassword_WithInvalidParameters_ResultObjectValidState()
    {
        var model = new User("User Name", "username@gmail.com", "123456", "15162901784", "TEST");
        Action action = () => model.UpdatePassword(string.Empty);
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("password"));
    }
    #endregion

    #region CPF Tests
    [Fact]
    public void CreateUser_ShortCpfValue_DomainExceptionShortCpf()
    {
        Action action = () => new User("User Name", "username@gmail.com", "123456", "1516290178", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.WithLength("cpf", 11));
    }

    [Fact]
    public void CreateUser_BigCpfValue_DomainExceptionBigCpf()
    {
        Action action = () => new User("User Name", "username@gmail.com", "123456", "151629017840", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.WithLength("cpf", 11));
    }

    [Fact]
    public void CreateUser_MissingCpfValue_DomainExceptionRequiredCpf()
    {
        Action action = () => new User("User Name", "username@gmail.com", "123456", string.Empty, "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("cpf"));
    }

    [Fact]
    public void CreateUser_WithNullCpfValue_DomainExceptionInvalidCpf()
    {
        Action action = () => new User("User Name", "username@gmail.com", "123456", null, "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("cpf"));
    }

    [Fact]
    public void CreateUser_WithInvalidCpfValue_DomainExceptionInvalidCpf()
    {
        Action action = () => new User("User Name", "username@gmail.com", "123456", "12345678911", "TEST");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.InvalidCpf());
    }
    #endregion

    #region Role Tests
    [Fact]
    public void CreateUser_BigRoleValue_DomainExceptionBigRole()
    {
        Action action = () => new User("User Name", "username@gmail.com", "123456", "15162901784", "frttcgyxukstpasvqpbhqmsbjjvolqsrbfkaiptymddeegoedgodnxtlotplntqitreugkiernzsjmganfdjxcyagoqrzmadqffbsvehnblaovkzclijojbbrustwczcilguchcmrfswjjwquyjbhwgdtnwysdxuymmaibjwvnpvemjxpdkirtjezwyifnrmngoodufstmndqcgawzlvqazxfhdhrtcditryoiczqabbpdhqgwqzukrenvvezlwiciwbprebrxuiytnumvupvoqtdfnbmoxrrgalrudecdugkfblogserwipsrbcqtmotleqarahfqxokfqmrsorjuofatcvsd");
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.MaxLength("role", 30));
    }

    [Fact]
    public void CreateUser_MissingRoleValue_DomainExceptionRequiredRole()
    {
        Action action = () => new User("User Name", "username@gmail.com", "123456", "15162901784", string.Empty);
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("role"));
    }

    [Fact]
    public void CreateUser_WithNullRoleValue_DomainExceptionInvalidRole()
    {
        Action action = () => new User("User Name", "username@gmail.com", "123456", "15162901784", null);
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("role"));
    }

    [Fact]
    public void UpdateUserRole_WithValidParameters_ResultObjectValidState()
    {
        var model = new User("User Name", "username@gmail.com", "123456", "15162901784", "TEST");
        Action action = () => model.UpdateRole("AAABBB");
        action.Should()
            .NotThrow<CopetSystem.Domain.Validation.DomainExceptionValidation>();
    }

    [Fact]
    public void UpdateUserRole_WithInvalidParameters_ResultObjectValidState()
    {
        var model = new User("User Name", "username@gmail.com", "123456", "15162901784", "TEST");
        Action action = () => model.UpdateRole(string.Empty);
        action.Should()
            .Throw<CopetSystem.Domain.Validation.DomainExceptionValidation>()
            .WithMessage(ExceptionMessageFactory.Required("role"));
    }
    #endregion
}
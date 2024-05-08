namespace ShopMicroService.User.Domain.Entities.Account;

public sealed class SmsCode : BaseEntities<ulong>
{
    #region properties

    public string PhoneNumber { get; set; }

    public string Code { get; set; }

    public bool Used { get; set; }

    public int RequestCount { get; set; }

    public DateTime InsertDate { get; set; }

    #endregion
}

namespace CarBooksy.Shared.Models;

public sealed class ContactInfo
{
    public string Phone { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Fax { get; private set; } = string.Empty;

    private ContactInfo() { }

    public ContactInfo(string phone, string email, string fax = "")
    {
        Phone = phone;
        Email = email;
        Fax = fax;
    }
}

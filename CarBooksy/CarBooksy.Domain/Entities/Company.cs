using System.Text.RegularExpressions;
using CarBooksy.Shared.Models.Addresses;
using CarBooksy.Shared.Models.Companies;
using CarBooksy.Shared.Models.ContactInfos;

namespace CarBooksy.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public Address Address { get; set; }
    public ContactInfo ContactInfo { get; set; }
    public string NIP { get; set; }

    private Company(){}
    
    public static Company Create(CreateCompanyCommandBase commandBase)
    {
        if (!IsValidNip(commandBase.NIP))
        {
            throw new Exception("Incorrect NIP – must be polish (PL) and have correct checksum.");
        }
        return new Company
        {
            Name = commandBase.Name,
            Address = commandBase.Address,
            ContactInfo = commandBase.ContactInfo,
            NIP = commandBase.NIP
        };
    }
    private static bool IsValidNip(string nip)
    {
        if (nip.Length != 10 || !nip.All(char.IsDigit))
            return false;

        int[] weights = { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
        int sum = 0;

        for (int i = 0; i < weights.Length; i++)
        {
            sum += (nip[i] - '0') * weights[i];
        }

        int control = sum % 11;
        if (control == 10) return false;

        int lastDigit = nip[9] - '0';
        return control == lastDigit;
    }

    public void Update(UpdateCompanyCommandBase commandBase)
    {
        Name = commandBase.Name;
        Address = commandBase.Address;
        ContactInfo = commandBase.ContactInfo;
        NIP = commandBase.NIP;
    }
}
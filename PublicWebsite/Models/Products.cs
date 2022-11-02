using System.ComponentModel.DataAnnotations;

namespace cheapdscin.Models
{
	public enum Products
	{
		[Display(Name = "Class 3 Individual Signature")]
		Class3IndividualSignature = 100,
		[Display(Name = "Class 3 Individual Signature With Usb Token")]
		Class3IndividualSignatureCombo = 105,

		[Display(Name = "Class 3 Individual Encryption")]
		Class3IndividualEncryption = 110,
		[Display(Name = "Class 3 Individual Encryption With Usb Token")]
		Class3IndividualEncryptionCombo = 115,

		[Display(Name = "Class 3 Individual Combo")]
		Class3IndividualSignWithEncrypt = 150,
		[Display(Name = "Class 3 Individual Combo With Usb Token")]
		Class3IndividualSignWithEncryptCombo = 155,


		[Display(Name = "Class 3 Organisation Signature")]
		Class3OrganisationSignature = 200,
		[Display(Name = "Class 3 Organisation Signature With Usb Token")]
		Class3OrganisationSignatureCombo = 205,

		[Display(Name = "Class 3 Organisation Encryption")]
		Class3OrganisationEncryption = 210,
		[Display(Name = "Class 3 Organisation Encryption With Usb Token")]
		Class3OrganisationEncryptionCombo = 215,

		[Display(Name = "Class 3 Organisation Combo")]
		Class3OrganisationSignWithEncrypt = 250,
		[Display(Name = "Class 3 Organisation Combo With Usb Token")]
		Class3OrganisationSignWithEncryptCombo = 255,


		[Display(Name = "DGFT Certificate")]
		Dgft = 400,
		[Display(Name = "DGFT Certificate With Usb Token")]
		DfgtCombo = 450,

		[Display(Name = "Usb Token")]
		UsbToken = 1000
	}
}
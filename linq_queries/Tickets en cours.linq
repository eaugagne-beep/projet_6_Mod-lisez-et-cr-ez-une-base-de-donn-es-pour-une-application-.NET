<Query Kind="Program">
  <Connection>
    <ID>59336676-939e-4dab-87a9-1d1065760432</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <UseMicrosoftDataSqlClient>true</UseMicrosoftDataSqlClient>
    <EncryptTraffic>true</EncryptTraffic>
    <Database>NexaWorks</Database>
    <MapXmlToString>false</MapXmlToString>
    <DriverData>
      <SkipCertificateCheck>true</SkipCertificateCheck>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	var ticketsEnCours = Issues
	    .Where(i => i.Status == "en_cours")
	    .Select(i => new
	    {
	        Produit = i.Version.Product.Name,
	        Version = i.Version.Version_number,
	        OS = i.OperatingSystem.Name,
	        DateCreation = i.Created_date,
	        i.Problem_description
	    })
	    .ToList();
	
	ticketsEnCours.Dump("Tickets en cours");
}

// You can define other methods, fields, classes and namespaces here

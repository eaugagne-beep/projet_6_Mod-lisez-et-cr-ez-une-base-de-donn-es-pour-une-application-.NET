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
	DateOnly debut = new DateOnly(2023, 6, 1);
	DateOnly fin = new DateOnly(2023, 12, 31);
	
	var ticketsResolus = Issues
	    .Where(i =>
	        i.Status == "resolu" &&
	        i.Created_date >= debut &&
	        i.Created_date <= fin
	    )
	    .Select(i => new
	    {
	        Produit = i.Version.Product.Name,
	        Version = i.Version.Version_number,
	        OS = i.OperatingSystem.Name,
	        i.Resolved_date,
	        i.Problem_description
	    })
	    .ToList();
	
	ticketsResolus.Dump("Tickets résolus sur la période");
}

// You can define other methods, fields, classes and namespaces here

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
	var stats = Issues
	    .GroupBy(i => i.Version.Product.Name)
	    .Select(g => new
	    {
	        Produit = g.Key,
	        NombreDeTickets = g.Count()
	    })
	    .ToList();
	
	stats.Dump("Nombre de tickets par produit");
}

// You can define other methods, fields, classes and namespaces here

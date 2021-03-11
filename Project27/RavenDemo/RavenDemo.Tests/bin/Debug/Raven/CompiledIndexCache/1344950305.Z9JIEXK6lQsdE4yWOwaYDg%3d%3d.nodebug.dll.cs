using Raven.Abstractions;
using Raven.Database.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Raven.Database.Linq.PrivateExtensions;
using Lucene.Net.Documents;
using System.Globalization;
using System.Text.RegularExpressions;
using Raven.Database.Indexing;


public class Index_Auto_2fProducts_2fByProductName : Raven.Database.Linq.AbstractViewGenerator
{
	public Index_Auto_2fProducts_2fByProductName()
	{
		this.ViewText = @"from doc in docs.Products
select new { ProductName = doc.ProductName }";
		this.ForEntityNames.Add("Products");
		this.AddMapDefinition(docs => 
			from doc in docs
			where string.Equals(doc["@metadata"]["Raven-Entity-Name"], "Products", System.StringComparison.InvariantCultureIgnoreCase)
			select new {
				ProductName = doc.ProductName,
				__document_id = doc.__document_id
			});
		this.AddField("ProductName");
		this.AddField("__document_id");
		this.AddQueryParameterForMap("ProductName");
		this.AddQueryParameterForMap("__document_id");
		this.AddQueryParameterForReduce("ProductName");
		this.AddQueryParameterForReduce("__document_id");
	}
}

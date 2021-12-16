using System;

public class Product : IEquatable<Product>
{
    public string productName { get; set; }

    public int productId { get; set; }

    public int productPrice { get; set; }

    public override string ToString()
    {
        return $"| {productId,5} | {productName,60} | ${productPrice,10} |";
    }

    public int GetId()
    {
        return productId;
    }

    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Product objAsProduct = obj as Product;
        if (objAsProduct == null) return false;
        else return Equals(objAsProduct);
    }

    public override int GetHashCode()
    {
        int hashProductName = productName == null ? 0 : productName.GetHashCode();

        int hashProductCode = productId.GetHashCode();

        return hashProductName ^ hashProductCode;
    }
    public bool Equals(Product other)
    {
        if (Object.ReferenceEquals(other, null)) return false;

        if (Object.ReferenceEquals(this, other)) return true;

        return productId.Equals(other.productId) && productName.Equals(other.productName);
    }
}

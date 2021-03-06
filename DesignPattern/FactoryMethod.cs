using System;
using System.Collections.Generic;

namespace DesignPattern.FactoryMethod
{
	namespace Framework{

		public abstract class Product
		{
			public abstract void Use();
		}

		public abstract class Factory
		{
			public Product Create(string owner)
			{
				Product p = CreateProduct (owner);
				RegisterProduct (p);
				return p;
			}

			protected abstract Product CreateProduct (string owner);
			protected abstract void RegisterProduct (Product product);
		}
	}

	namespace IdCard
	{
		using Framework;

		public class IDCard:Product
		{
			public string Owner{ get; private set; }

			public IDCard(string owner)
			{
				Console.WriteLine ("Create " + owner + "'s ID card");
				this.Owner = owner;
			}

			public override void Use()
			{
				Console.WriteLine ("Use " + this.Owner + "'s ID card.");
			}
		}

		public class IDCardFactory:Factory
		{
			private SortedDictionary<int,string> owners = new SortedDictionary<int, string> ();
			private int currentNumber;

			protected override Product CreateProduct(string owner)
			{
				return new IDCard (owner);
			}

			protected override void RegisterProduct(Product product)
			{
				this.owners.Add (currentNumber, ((IDCard)product).Owner);
				currentNumber++;
			}

			public SortedDictionary<int, string> GetOwners()
			{
				return this.owners;
			}
		}
	}
}


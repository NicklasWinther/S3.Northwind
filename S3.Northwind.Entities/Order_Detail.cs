namespace S3.Northwind.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order Details")]
    public partial class Order_Detail
    {
        /// <summary>
        /// Gets or sets the ID of the order
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the product
        /// </summary>
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the price per unit
        /// </summary>
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the number of units
        /// </summary>
        public short Quantity { get; set; }

        /// <summary>
        /// Gets or sets the amount of discount
        /// </summary>
        public float Discount { get; set; }

        /// <summary>
        /// The Order
        /// </summary>
        public virtual Order Order { get; set; }
        
        /// <summary>
        /// The Product
        /// </summary>
        public virtual Product Product { get; set; }
    }
}

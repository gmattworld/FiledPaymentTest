﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FiledPaymentTest.Core.Entities
{
    public class BaseEntity<TKey>
    {
        /// <summary>
        /// Get or set entity ID
        /// </summary>
        [Required]
        [MaxLength(50)]
        public virtual TKey Id { get; set; }

        /// <summary>
        /// Get or set date an entity record is created (Default to current date)
        /// </summary>
        public virtual DateTime CreatedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Get or set date an entity was last updated (Default to min date)
        /// </summary>
        public virtual DateTime ModifiedAt { get; set; } = DateTime.MinValue;
    }
}

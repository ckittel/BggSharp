﻿using System.Collections.Generic;

namespace BggSharp.Models.HttpResponse.Plays
{
    // TODO: Make internal by providing our own return type and remove warnings below then
    public class ItemSubtypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists"), 
        System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public List<ItemSubtype> Subtypes { get; set; }
    }
}
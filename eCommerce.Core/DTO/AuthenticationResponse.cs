using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.DTO
{
    // This record represents the data transfer object for an login and registration response.
    public record AuthenticationResponse(
        Guid UserID,
        string? Email,
        string? PersonName,
        string? Gender,
        string? Token,
        bool Success
    )
    {
        // By default records have parameterized primary constructor, but we can also define a secondary parameterless constructor if needed (e.g., for Automapper to work, deserialization purposes)
        // Constructor chaining is required here because records with primary constructors do not have an implicit parameterless constructor,
        // so we need to explicitly call the primary constructor with default values.
        public AuthenticationResponse() : this(default, default, default, default, default, default)  
        {
            
        }
    };
}

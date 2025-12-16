using Microsoft.AspNetCore.Mvc;
using core_erp.Models;
using System.Collections.Concurrent;

namespace core_erp.Controllers
{
    [ApiController]
    [Route("api/contracts")]
    public class ContractsDraftController : ControllerBase
    {
        private static readonly ConcurrentDictionary<string, ContractDraft> Drafts = new();

        [HttpPost("draft")]
        public ActionResult<ContractDraft> CreateDraft([FromBody] ContractDraft payload)
        {
            var draft = new ContractDraft
            {
                Id = Guid.NewGuid().ToString(),
                CustomerId = payload.CustomerId,
                Products = payload.Products,
                Budget = payload.Budget,
                Suggestion = payload.Suggestion,
                TenantId = payload.TenantId,
                Status = "PENDING_APPROVAL"
            };
            Drafts[draft.Id] = draft;
            return Ok(draft);
        }
    }

    public class ContractDraft
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public IEnumerable<string> Products { get; set; }
        public decimal? Budget { get; set; }
        public object Suggestion { get; set; }
        public string TenantId { get; set; }
        public string Status { get; set; }
    }
}

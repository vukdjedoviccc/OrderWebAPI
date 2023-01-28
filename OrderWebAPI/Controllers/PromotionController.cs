using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Request;
using Order.Domain.Services;

namespace Order.Domain.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        
        private readonly IPromotionService _promotionService;
       
        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        
        [HttpPut("{id}")]
        public async Task Put(int id, CreatePromotionRequest promotionRequest)
        {
            var promotion = await _promotionService.GetById(id);
            if (promotion != null)
            {
                promotion.FromDate = promotionRequest.FromDate;
                promotion.ToDate = promotionRequest.ToDate;
                promotion.Discount = promotionRequest.Discount;
                promotion.Name = promotionRequest.Name;
                // sada treba da napraviš objekte Product-a koje dodaješ
                // u listu Product-a koju na kraju lepiš na Promotion
                List<int> productIds = new List<int>();
                foreach (var productId in promotionRequest.ProductIds)
                    productIds.Add(productId);
                await _promotionService.Update(promotion, productIds);
            }
        }

        
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Promotion>>> GetAll()
        {
            return await _promotionService.GetAll();
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<Promotion>> GetById(int id)
        {
           return await _promotionService.GetById(id);
        }

        
        [HttpDelete("{id}")]
        public async Task DeleteById(int id)
        {
            await _promotionService.DeleteById(id);
        }

       
        [HttpPost]
        public async Task Post(CreatePromotionRequest promotionRequest)
        {
            Promotion promotion = new Promotion();
            promotion.Name = promotionRequest.Name;
            promotion.FromDate = promotionRequest.FromDate;
            promotion.ToDate = promotionRequest.ToDate; 
            promotion.Discount = promotionRequest.Discount;
            await _promotionService.Add(promotion, promotionRequest.ProductIds);
        }
    }
}

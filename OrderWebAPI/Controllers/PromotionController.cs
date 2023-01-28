using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Request;
using Order.Domain.Services;

namespace Order.Domain.Controllers
{
    /// <summary>
    /// Kontroler koji služi za pozivanje operacija nad objektom "Promotion"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        /// <summary>
        /// Properti interfejsa servisa promocije koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly IPromotionService _promotionService;
        /// <summary>
        /// Konstruktor sa parametrom servisa promocije koji inicijalizuje ovaj servis
        /// </summary>
        /// <param name="promotionService"></param>
        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }

        /// <summary>
        /// Metoda koja služi za ažuriranje promocije u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="promotionRequest"></param>
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

        /// <summary>
        /// Metoda koja služi za vraćanje liste svih promocija iz baze
        /// </summary>
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Promotion>>> GetAll()
        {
            return await _promotionService.GetAll();
        }

        /// <summary>
        /// Metoda koja služi za vraćanje konkretne promocije iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Promotion>> GetById(int id)
        {
           return await _promotionService.GetById(id);
        }

        /// <summary>
        /// Metoda koja služi za brisanje konkretne promocije iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task DeleteById(int id)
        {
            await _promotionService.DeleteById(id);
        }

        /// <summary>
        /// Metoda koja služi za dodavanje nove promocije u bazu
        /// </summary>
        /// <param name="promotionRequest"></param>
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

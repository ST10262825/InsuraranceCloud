using KCrafts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class TransactionsController : Controller
{
    private readonly KcraftContext _context;

    public TransactionsController(KcraftContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Transaction transaction)
    {
        if (ModelState.IsValid)
        {
            // Save transaction details
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();

            // Retrieve cart items
            var cartItems = await _context.CartItems
                                .Include(ci => ci.Product)
                                .Where(ci => ci.UserId == User.Identity.Name) // assuming User.Identity.Name is used as user identifier
                                .ToListAsync();

            // Clear the cart
            _context.CartItems.RemoveRange(cartItems);
            await _context.SaveChangesAsync();

            // Redirect to OrderSummary view
            return RedirectToAction("OrderSummary", new { transactionId = transaction.TransactionId });
        }


        return View(transaction);
    }

    [HttpGet]
    public IActionResult OrderSummary()
    {
       

        return View();
    }
}

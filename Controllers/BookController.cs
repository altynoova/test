using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test;

public class BookController : Controller
{
    private readonly ApplicationDBContext _context;
    public BookController(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> IndexAsync()
    {
        return View(await _context.Books.ToListAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(Book book)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        catch
        {
            return NotFound();
        }

        return View(book);
    }

    public IActionResult Details(int? id)
    {
        if (id == null) return NotFound();

        var item = _context.Books.FirstOrDefault(x => x.IdBook == id);

        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    public async Task<IActionResult> Delete(int? id)
    {

        if (id == null) return NotFound();
        var item = _context.Books.FirstOrDefault(x => x.IdBook == id);

        if (item == null)
        {
            return NotFound();
        }

        _context.Remove(item);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");

    }

    [HttpGet]
    public IActionResult Update(int? id)
    {
        if (id == null) return NotFound();
        var item = _context.Books.FirstOrDefault(x => x.IdBook == id);

        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateAsync(Book book)
    {

        if (book == null) return NotFound();
        var item = _context.Books.FirstOrDefault(x => x.IdBook == book.IdBook);

        if (item == null)
        {
            return NotFound();
        }

        if (await TryUpdateModelAsync<Book>(
        item,
        "",
        s => s.BookName, s => s.AuthorName, s => s.PublishDate, s => s.AmountOfPages, s => s.Ratings))
        {
            try
            {
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {

            }
        }
        return View(item);
    }

}
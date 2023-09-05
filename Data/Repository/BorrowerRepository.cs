using Models;

namespace Data.Repository;

public class BorrowerRepository : IBorrowerRepository
{
    private List<Borrower> borrowers = new List<Borrower>
    {
        new Borrower("Thomas Jensen"),
        new Borrower("Søren Hansen"),
    };

    public IList<Borrower> GetBorrowers()
    {
        return borrowers;
    }

    public Borrower GetBorrower(Guid id)
    {
        return borrowers.FirstOrDefault(x => x.Id == id) ?? throw new InvalidOperationException();
    }

    public Borrower CreateBorrower(Borrower borrower)
    {
        borrowers.Add(borrower);
        return borrower;
    }

    public bool BorrowerExists(Guid id)
    {
        return borrowers.Any(x => x.Id == id);
    }

    public Borrower UpdateBorrower(Guid id, Borrower borrower)
    {
        var borrowerToUpdate = GetBorrower(id);
        borrowerToUpdate.Name = borrowerToUpdate.Name;
        return borrowerToUpdate;
    }

    public void DeleteBorrower(Guid id)
    {
        borrowers.Remove(GetBorrower(id));
    }
}
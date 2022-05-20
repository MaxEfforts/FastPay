namespace FastPayDB.DatabaseModels.Base;

public interface IBaseDataModel
{
    public int Id { get; set; }

    public bool IsPublished { get; set; }

    public DateTime? CreatedOnUtc { get; set; }

    public bool IsDeleted { get; set; } // 
}
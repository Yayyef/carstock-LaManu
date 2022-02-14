namespace Carstock.Models
{
    public class ClientCatalogueViewModel
    {
        // Création d'un ViewModel en vue d'obtenir un modèle fortement typé pour le catalogue et obtenir plus facilement le stock de voitures par modèle.
        public IQueryable<Carmodel> Carmodels { get; set; }
        public List<Car> Cars { get; set; }
        public string? SelectedBrand { get; set; }
        public string? SelectedType { get; set; }
        public string? SelectedCategory { get; set; }
        public IQueryable<string> Brands { get; set; }
        public IQueryable<string> Types { get; set; }
        public IQueryable<string> Categories { get; set; }

    }
}

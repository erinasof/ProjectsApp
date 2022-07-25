using ProjectsApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProjectsApp.ViewModels
{
    public class ProjectsListViewModel : ListViewModel
    {
        public ObservableCollection<ProjectViewModel> AllProjects { get; set; }
        public ObservableCollection<ProjectViewModel> Projects { get; set; }

        private ProjectViewModel _selectedProject;
        private string _searchText;
        private bool _startDateIsChecked;
        private bool _finishDateIsChecked;
        private DateTime _minStartDate;
        private DateTime _maxFinishDate;

        public ICommand SearchCommand { protected set; get; }

        public ICommand NameSortingCommand { protected set; get; }
        public ICommand PrioritySortingCommand { protected set; get; }
        public ICommand StartDateSortingCommand { protected set; get; }
        public ICommand FinishDateSortingCommand { protected set; get; }

        public ProjectsListViewModel()
        {
            Projects = new ObservableCollection<ProjectViewModel>();
            AllProjects = new ObservableCollection<ProjectViewModel>();
            StartDateIsChecked = false;
            FinishDateIsChecked = false;
            MinStartDate = DateTime.Today;
            MaxFinishDate = DateTime.Today;
            SearchText = string.Empty;
            ReloadTable();
            CreateCommand = new Command(CreateProject);
            DeleteCommand = new Command(DeleteProject);
            SaveCommand = new Command(SaveProject);
            BackCommand = new Command(Back);
            PageDisappearingCommand = new Command(ReloadTable);
            SearchCommand = new Command(ToSearchText);

            NameSortingCommand = new Command(NameSort);
            PrioritySortingCommand = new Command(PrioritySort);
            StartDateSortingCommand = new Command(StartDateSort);
            FinishDateSortingCommand = new Command(FinishDateSort);
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged("SearchText");
            }
        }

        public bool StartDateIsChecked
        {
            get => _startDateIsChecked;
            set
            {
                _startDateIsChecked = value;
                OnPropertyChanged("StartDateIsChecked");
                ToSearchText();
            }
        }

        public bool FinishDateIsChecked
        {
            get => _finishDateIsChecked;
            set
            {
                _finishDateIsChecked = value;
                OnPropertyChanged("FinishDateIsChecked");
                ToSearchText();
            }
        }

        public DateTime MinStartDate
        {
            get => _maxFinishDate;
            set
            {
                _maxFinishDate = value;
                OnPropertyChanged("MinStartDate");
                ToSearchText();
            }
        }

        public DateTime MaxFinishDate
        {
            get => _minStartDate;
            set
            {
                _minStartDate = value;
                OnPropertyChanged("MaxFinishDate");
                ToSearchText();
            }
        }

        public ProjectViewModel SelectedProject
        {
            get => _selectedProject;
            set
            {
                if (_selectedProject != value)
                {
                    ProjectViewModel tempProject = value;
                    _selectedProject = null;
                    OnPropertyChanged("SelectedProject");
                    Navigation.PushAsync(new ProjectPage(tempProject));
                }
            }
        }

        private void NameSort()
        {
            var TempProjects = Projects.ReplaceCollection();
            Projects.SetCollection(TempProjects.OrderBy(project => project.Name));
        }

        private void PrioritySort()
        {
            var TempProjects = Projects.ReplaceCollection();
            Projects.SetCollection(TempProjects.OrderBy(project => project.Project.Priority));
        }

        private void StartDateSort()
        {
            var TempProjects = Projects.ReplaceCollection();
            Projects.SetCollection(TempProjects.OrderBy(project => project.Project.StartDate));
        }

        private void FinishDateSort()
        {
            var TempProjects = Projects.ReplaceCollection();
            Projects.SetCollection(TempProjects.OrderBy(project => project.Project.FinishDate));
        }

        private void ToSearchText()
        {
            Projects.SetCollection(AllProjects.Where(pr => pr.Name.Contains(SearchText) &&
                (!StartDateIsChecked || pr.Project.StartDate >= MinStartDate) &&
                (!FinishDateIsChecked || pr.Project.FinishDate <= MaxFinishDate)
            ));
        }

        private void ReloadTable()
        {
            AllProjects.SetCollection(App.Database.GetProjectItems().Select(x => new ProjectViewModel(x) { ListViewModel = this }));
            Projects.SetCollection(AllProjects);
            ToSearchText();
        }

        private void CreateProject()
        {
            Navigation.PushAsync(new ProjectPage(new ProjectViewModel() { ListViewModel = this }));
        }

        private void Back()
        {
            Navigation.PopAsync();
        }

        private async void SaveProject(object projectObject)
        {
            if (projectObject is ProjectViewModel project && project.IsValid)
            {
                if (!Projects.Contains(project))
                {
                    Projects.Add(project);
                }
                App.Database.SaveProjectItem(project.Project);
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Уведомление", "Проект не добавлен/изменен", "Ok");
            }

            Back();
        }

        private void DeleteProject(object projectObject)
        {
            if (projectObject is ProjectViewModel project)
            {
                Projects.Remove(project);
                App.Database.DeleteProjectItem(project.Id);
            }

            Back();
        }
    }
}

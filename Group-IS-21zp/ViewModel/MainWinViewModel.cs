using Group_IS_21zp.Model;
using Group_IS_21zp.Repository;
using Group_IS_21zp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Group_IS_21zp.Commands;

namespace Group_IS_21zp.ViewModels
{
    public class MainWinViewModel : ViewModelBase, IDataErrorInfo

    {

        StudentRepository studentRepo;
        TeacherRepository teacherRepo;
        SubjectRepository subjectRepo;

        ObservableCollection<IExcelItem> _students = new ObservableCollection<IExcelItem>();
        ObservableCollection<IExcelItem> _teachers = new ObservableCollection<IExcelItem>();
        ObservableCollection<IExcelItem> _subjects = new ObservableCollection<IExcelItem>();

        private string _studentListView = "Visible";
        private string _editStudentView = "Hidden";

        private string _teacherListView = "Visible";
        private string _editTeacherView = "Hidden";

        private string _subjectListView = "Visible";
        private string _editSubjectView = "Hidden";

        public string StudentFirstName
        {
            get => _studentFirstName;
            set
            {
                _studentFirstName = value;
                OnPropertyChanged("StudentFirstName");
            }
        }
        public string StudentLastName
        {
            get => _studentLastName;
            set
            {
                _studentLastName = value;
                OnPropertyChanged("StudentLastName");
            }
        }
        public string StudentPatronymicName
        {
            get => _studentPatronymicName;
            set
            {
                _studentPatronymicName = value;
                OnPropertyChanged("StudentPatronymicName");
            }
        }


        public string TeacherFirstName
        {
            get => _teacherFirstName;
            set
            {
                _teacherFirstName = value;
                OnPropertyChanged("TeacherFirstName");
            }
        }
        public string TeacherLastName
        {
            get => _teacherLastName;
            set
            {
                _teacherLastName = value;
                OnPropertyChanged("TeacherLastName");
            }
        }
        public string TeacherPatronymicName
        {
            get => _teacherPatronymicName;
            set
            {
                _teacherPatronymicName = value;
                OnPropertyChanged("TeacherPatronymicName");
            }
        }

        public string SubjectName
        {
            get => _studentPatronymicName;
            set
            {
                _studentPatronymicName = value;
                OnPropertyChanged("SubjectName");
            }
        }

        bool StudentFirstNameValidationPassed { get; set; } = false;
        bool StudentLastNameValidationPassed { get; set; } = false;
        bool StudentPatronymicNameValidationPassed { get; set; } = false;

        bool TeacherFirstNameValidationPassed { get; set; } = false;
        bool TeacherLastNameValidationPassed { get; set; } = false;
        bool TeacherPatronymicNameValidationPassed { get; set; } = false;

        bool SubjectNameValidationPassed { get; set; } = false;


        public string StudentListView
        {
            get => _studentListView;
            set
            {
                _studentListView = value;
                OnPropertyChanged("StudentListView");
            }
        }
        public string EditStudentView
        {
            get => _editStudentView;
            set
            {
                _editStudentView = value;

                OnPropertyChanged("EditStudentView");
            }
        }



        public string TeacherListView
        {
            get => _teacherListView;
            set
            {
                _teacherListView = value;
                OnPropertyChanged("TeacherListView");
            }
        }
        public string EditTeacherView
        {
            get => _editTeacherView;
            set
            {
                _editTeacherView = value;

                OnPropertyChanged("EditTeacherView");
            }
        }


        public string SubjectListView
        {
            get => _subjectListView;
            set
            {
                _subjectListView = value;
                OnPropertyChanged("SubjectListView");
            }
        }
        public string EditSubjectView
        {
            get => _editSubjectView;
            set
            {
                _editSubjectView = value;

                OnPropertyChanged("EditSubjectView");
            }
        }


        public MainWinViewModel()
        {
            //STUDENTS
            studentRepo = new StudentRepository();
            foreach (var item in studentRepo.GetItems())
            {
                Students.Add(item);
                Console.WriteLine(item);
            }
            
            AddStudentCmd = new RelayCommand(o => { AddStudent(); }, AddStudentCanExecute);
            DeleteStudentCmd = new RelayCommand(o => { DeleteStudent(); }, DeleteStudentCanExecute);
            UpdateStudentCmd = new RelayCommand(o => { UpdateStudent(); }, UpdateStudentCanExecute);


            //TEACHERS
            teacherRepo = new TeacherRepository();
            foreach (var item in teacherRepo.GetItems())
            {
                Teachers.Add(item);
                Console.WriteLine(item);
            }

            AddTeacherCmd = new RelayCommand(o => { AddTeacher(); }, AddTeacherCanExecute);
            DeleteTeacherCmd = new RelayCommand(o => { DeleteTeacher(); }, DeleteTeacherCanExecute);
            UpdateTeacherCmd = new RelayCommand(o => { UpdateTeacher(); }, UpdateTeacherCanExecute);


            OkActionCmd = new RelayCommand(o => { OkAction(); }, OkActionCanExecute);
            CancelActionCmd = new RelayCommand(o => { CancelAction(); }, (arg) => true);

            //SUBJECTS
            subjectRepo = new SubjectRepository();
            foreach (var item in subjectRepo.GetItems())
            {
                Subjects.Add(item);
                Console.WriteLine(item);
            }

            AddSubjectCmd = new RelayCommand(o => { AddSubject(); }, AddSubjectCanExecute);
            DeleteSubjectCmd = new RelayCommand(o => { DeleteSubject(); }, DeleteSubjectCanExecute);
            UpdateSubjectCmd = new RelayCommand(o => { UpdateSubject(); }, UpdateSubjectCanExecute);


        }

        private void UpdateSubject()
        {
            SubjectListView = "Collapsed";
            EditSubjectView = "Visible";
            MessengerStatic.NotifySubjectEditing(null);
            CurrentViewMode = ViewMode.SubjectEdition;

            SubjectName = SelectedSubjectItem.Name;
        }

        private void DeleteSubject()
        {
            subjectRepo.RemoveItem(SelectedSubjectItem.Id);
            _subjects.Remove(SelectedSubjectItem);
        }

        private void AddSubject()
        {
            SubjectListView = "Collapsed";
            EditSubjectView = "Visible";
            MessengerStatic.NotifySubjectEditing(null);
            SubjectName = "";


            CurrentViewMode = ViewMode.SubjectAddition;
        }

        private bool UpdateSubjectCanExecute(object arg)
        {
            return true;
        }

        private bool DeleteSubjectCanExecute(object arg)
        {
            return true;
        }

        private bool AddSubjectCanExecute(object arg)
        {
            return true;
        }

        Student _selectedStudentItem;
        private string _studentFirstName = "";
        private string _studentLastName = "";
        private string _studentPatronymicName = "";


        Teacher _selectedTeacherItem;
        private string _teacherFirstName = "";
        private string _teacherLastName = "";
        private string _teacherPatronymicName = "";

        public Student SelectedStudentItem
        {
            get => _selectedStudentItem;
            set => _selectedStudentItem = value;
        }

        public Teacher SelectedTeacherItem
        {
            get => _selectedTeacherItem;
            set => _selectedTeacherItem = value;
        }

        Subject _selectedSubjectItem;
        public Subject SelectedSubjectItem
        {
            get => _selectedSubjectItem;
            set => _selectedSubjectItem = value;
        }


        private bool DeleteStudentCanExecute(object arg)
        {
            return true;
        }

        private void DeleteStudent()
        {
            studentRepo.RemoveItem(SelectedStudentItem.Id);
            _students.Remove(SelectedStudentItem);
        }


        private bool DeleteTeacherCanExecute(object arg)
        {
            return true;
        }

        private void DeleteTeacher()
        {
            teacherRepo.RemoveItem(SelectedTeacherItem.Id);
            _teachers.Remove(SelectedTeacherItem);
        }

        private bool OkActionCanExecute(object arg)
        {
            if(ViewMode.StudentAddition == CurrentViewMode || ViewMode.StudentEdition == CurrentViewMode)
            {
                if (StudentFirstName == "" || StudentLastName == "" || StudentPatronymicName == "")
                {
                    return false;
                }
                else if (StudentFirstNameValidationPassed && StudentLastNameValidationPassed && StudentPatronymicNameValidationPassed)
                { return true; }
                else { return false; }
            }
            else if (ViewMode.TeacherAddition == CurrentViewMode || ViewMode.TeacherEdition == CurrentViewMode)
            {
                if (TeacherFirstName == "" || TeacherLastName == "" || TeacherPatronymicName == "")
                {
                    return false;
                }
                else if (TeacherFirstNameValidationPassed && TeacherLastNameValidationPassed && TeacherPatronymicNameValidationPassed)
                { return true; }
                else { return false; }
            } else if (ViewMode.SubjectAddition == CurrentViewMode || ViewMode.SubjectEdition == CurrentViewMode)
            {
                if (SubjectName == "") { return false; }
                else if (SubjectNameValidationPassed) { return true; }
                else { return false;  }
            }
            else
            { return false; }
        }


        public void CancelAction()
        {
            if (CurrentViewMode == ViewMode.StudentAddition || CurrentViewMode == ViewMode.StudentEdition)
            {
                StudentListView = "Visible";
                EditStudentView = "Hidden";
            } else if (CurrentViewMode == ViewMode.TeacherAddition || CurrentViewMode == ViewMode.TeacherEdition)
            {
                TeacherListView = "Visible";
                EditTeacherView = "Hidden";
            } else if (CurrentViewMode == ViewMode.SubjectAddition || CurrentViewMode == ViewMode.SubjectEdition)
            {
                SubjectListView = "Visible";
                EditSubjectView = "Hidden";
            }

        }

        public void OkAction()
        {
            if (CurrentViewMode == ViewMode.StudentAddition)
            {
                IExcelItem newStudent = studentRepo.AddItem(new Student(0, StudentFirstName, StudentPatronymicName, StudentLastName));
                _students.Add((Student)newStudent);
                StudentListView = "Visible";
                EditStudentView = "Hidden";
            } else if ( CurrentViewMode == ViewMode.StudentEdition)
            {
                Student modifiedStudent = new Student(SelectedStudentItem.Id, StudentFirstName, 
                    StudentPatronymicName, StudentLastName);
                foreach (Student student in Students)
                {
                    if (student.Id == modifiedStudent.Id)
                    {
                        student.FirstName = modifiedStudent.FirstName;
                        student.PatronymicName = modifiedStudent.PatronymicName;
                        student.LastName = modifiedStudent.LastName;
                    }
                }

                studentRepo.UpdateItem(modifiedStudent);
                Students.Clear();
                foreach (var item in studentRepo.GetItems())
                {
                    Students.Add(item);
                }
                StudentListView = "Visible";
                EditStudentView = "Hidden";
            } else if (CurrentViewMode == ViewMode.TeacherAddition)
            {
                IExcelItem newTeacher = teacherRepo.AddItem(new Teacher(0, TeacherFirstName, TeacherPatronymicName, TeacherLastName));
                _teachers.Add((Teacher)newTeacher);
                TeacherListView = "Visible";
                EditTeacherView = "Hidden";

            }
            else if (CurrentViewMode == ViewMode.TeacherEdition)
            {
                Teacher modifiedTeacher = new Teacher(SelectedTeacherItem.Id, TeacherFirstName,
                    TeacherPatronymicName, TeacherLastName);
                foreach (Teacher teacher in Teachers)
                {
                    if (teacher.Id == modifiedTeacher.Id)
                    {
                        teacher.FirstName = modifiedTeacher.FirstName;
                        teacher.PatronymicName = modifiedTeacher.PatronymicName;
                        teacher.LastName = modifiedTeacher.LastName;
                    }
                }

                teacherRepo.UpdateItem(modifiedTeacher);
                Teachers.Clear();
                foreach (var item in teacherRepo.GetItems())
                {
                    Teachers.Add(item);
                }
                TeacherListView = "Visible";
                EditTeacherView = "Hidden";
            } else if (CurrentViewMode == ViewMode.SubjectAddition)
            {
                IExcelItem newSubject = subjectRepo.AddItem(new Subject(0, SubjectName));
                _subjects.Add((Subject)newSubject);
                SubjectListView = "Visible";
                EditSubjectView = "Hidden";
            }
            else if (CurrentViewMode == ViewMode.SubjectEdition)
            {
                Subject modifiedSubject = new Subject(SelectedSubjectItem.Id, SubjectName);
                foreach (Subject subject in Subjects)
                {
                    if (subject.Id == modifiedSubject.Id)
                    {
                        subject.Name = modifiedSubject.Name;
                    }
                }

                subjectRepo.UpdateItem(modifiedSubject);
                Subjects.Clear();
                foreach (var item in subjectRepo.GetItems())
                {
                    Subjects.Add(item);
                }
                SubjectListView = "Visible";
                EditSubjectView = "Hidden";
            }
        }

        private bool AddStudentCanExecute(object arg)
        {
            return true;
        }

        private void AddStudent()
        {
            StudentListView = "Collapsed";
            EditStudentView = "Visible";
            MessengerStatic.NotifyStudentEditing(null);
            StudentFirstName = "";
            StudentLastName = "";
            StudentPatronymicName = "";

            CurrentViewMode = ViewMode.StudentAddition;
        }


        private bool AddTeacherCanExecute(object arg)
        {
            return true;
        }

        private void AddTeacher()
        {
            TeacherListView = "Collapsed";
            EditTeacherView = "Visible";
            MessengerStatic.NotifyStudentEditing(null);
            TeacherFirstName = "";
            TeacherLastName = "";
            TeacherPatronymicName = "";

            CurrentViewMode = ViewMode.TeacherAddition;
        }

        private bool UpdateStudentCanExecute(object arg)
        {
            return true;
        }

        private void UpdateStudent()
        {
            StudentListView = "Collapsed";
            EditStudentView = "Visible";
            MessengerStatic.NotifyStudentEditing(null);
            CurrentViewMode = ViewMode.StudentEdition;

            StudentFirstName = SelectedStudentItem.FirstName;
            StudentLastName = SelectedStudentItem.LastName;
            StudentPatronymicName = SelectedStudentItem.PatronymicName;

            //Student modifiedStudent = new Student(SelectedStudentItem.Id, StudentFirstName,
            //    StudentPatronymicName, StudentLastName);
        }

        private void UpdateTeacher()
        {
            TeacherListView = "Collapsed";
            EditTeacherView = "Visible";
            MessengerStatic.NotifyTeacherEditing(null);
            CurrentViewMode = ViewMode.TeacherEdition;

            TeacherFirstName = SelectedTeacherItem.FirstName;
            TeacherLastName = SelectedTeacherItem.LastName;
            TeacherPatronymicName = SelectedTeacherItem.PatronymicName;

        }

        private bool UpdateTeacherCanExecute(object arg)
        {
            return true;
        }


        public ObservableCollection<IExcelItem> Students
        {
            get => _students; set
            {
                _students = value;
                OnPropertyChanged("Students");
            }
        }

        public ObservableCollection<IExcelItem> Teachers
        {
            get => _teachers; set
            {
                _teachers = value;
                OnPropertyChanged("Teachers");
            }
        }

        public ObservableCollection<IExcelItem> Subjects
        {
            get => _subjects; set
            {
                _subjects = value;
                OnPropertyChanged("Subjects");
            }
        }

        public RelayCommand AddStudentCmd { get; private set; }
        public RelayCommand DeleteStudentCmd { get; private set; }
        public RelayCommand UpdateStudentCmd { get; private set; }

        public RelayCommand AddTeacherCmd { get; private set; }
        public RelayCommand DeleteTeacherCmd { get; private set; }
        public RelayCommand UpdateTeacherCmd { get; private set; }


        public RelayCommand AddSubjectCmd { get; private set; }
        public RelayCommand DeleteSubjectCmd { get; private set; }
        public RelayCommand UpdateSubjectCmd { get; private set; }

        public RelayCommand OkActionCmd { get; private set; }
        public RelayCommand CancelActionCmd { get; private set; }
        public ViewMode CurrentViewMode { get; private set; }

        public string Error => null;

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "StudentFirstName":
                        StudentFirstNameValidationPassed = true;
                        foreach (char c in StudentFirstName)
                        {
                            if (!Char.IsLetter(c))
                            {
                                error = "Please check First name";
                                StudentFirstNameValidationPassed = false;
                            }

                        }
                        break;
                    case "StudentLastName":
                        StudentLastNameValidationPassed = true;
                        foreach (char c in StudentLastName)
                        {
                            if (!Char.IsLetter(c) && c != '-')
                            {
                                error = "Please check Last name";
                                StudentLastNameValidationPassed = false;
                            }
                        }
                        break;
                    case "StudentPatronymicName":
                        StudentPatronymicNameValidationPassed = true;
                        foreach (char c in StudentPatronymicName)
                        {
                            if (!Char.IsLetter(c))
                            {
                                error = "Please check Patronymic name";
                                StudentPatronymicNameValidationPassed = false;
                            }
                        }
                        break;

                    case "TeacherFirstName":
                        TeacherFirstNameValidationPassed = true;
                        foreach (char c in TeacherFirstName)
                        {
                            if (!Char.IsLetter(c))
                            {
                                error = "Please check First name";
                                TeacherFirstNameValidationPassed = false;
                            }
                        }
                        break;
                    case "TeacherLastName":
                        TeacherLastNameValidationPassed = true;
                        foreach (char c in TeacherLastName)
                        {
                            if (!Char.IsLetter(c) && c != '-')
                            {
                                error = "Please check Last name";
                                TeacherLastNameValidationPassed = false;
                            }
                        }
                        break;
                    case "TeacherPatronymicName":
                        TeacherPatronymicNameValidationPassed = true;
                        foreach (char c in TeacherPatronymicName)
                        {
                            if (!Char.IsLetter(c))
                            {
                                error = "Please check Patronymic name";
                                TeacherPatronymicNameValidationPassed = false;
                            }
                        }
                        break;
                    case "SubjectName":
                        SubjectNameValidationPassed = true;
                        foreach (char c in TeacherPatronymicName)
                        {
                            if (!Char.IsLetter(c))
                            {
                                error = "Please check name";
                                SubjectNameValidationPassed = false;
                            }
                        }
                        break;
                }
                return error;
            }
        }


    }

}

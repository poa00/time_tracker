﻿using System;
using System.Windows.Input;

namespace Ficksworkshop.TimeTrackerAPI.Commands
{
    /// <summary>
    /// A standard command that sets the project status to closed.
    /// 
    /// This command required bound command pameter that specified the <see cref="IProjectTimesData"/> to add to.
    /// </summary>
    public class CloseProjectCommand : ICommand
    {
        /// <inheritdoc />
        public void Execute(object parameter)
        {
            var project = parameter as IProject;
            if (project != null)
            {
                project.Status = ProjectStatus.Closed;
            }
        }

        /// <inheritdoc />
        /// <remarks>We can execute if there is a context and a project.</remarks>
        public bool CanExecute(object parameter)
        {
            var project = parameter as IProject;
            return project != null && project.Status != ProjectStatus.Closed;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
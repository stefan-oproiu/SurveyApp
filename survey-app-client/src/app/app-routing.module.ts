import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login/login.component';
import { RegisterComponent } from './register/register/register.component';
import { AuthGuard } from './services/auth.guard';
import { ShellComponent } from './shell/shell.component';
import { QuestionsComponent } from './shell/questions/questions.component';
import { AdminGuard } from './services/admin.guard';
import { SubmissionsComponent } from './shell/submissions/submissions.component';
import { SurveysComponent } from './shell/surveys/surveys.component';
import { SurveyComponent } from './shell/survey/survey.component';

const routes: Routes = [
  {
    path: '',
    component: ShellComponent,
    children: [
      { path: 'questions', component: QuestionsComponent, canActivate: [AdminGuard] },
      { path: 'submissions', component: SubmissionsComponent, canActivate: [AdminGuard] },
      {
        path: 'surveys', canActivate: [AuthGuard], children: [
          { path: '', component: SurveysComponent },
          { path: ':id', component: SurveyComponent }
        ]
      }
    ],
    canActivate: [AuthGuard]
  },
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component: RegisterComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

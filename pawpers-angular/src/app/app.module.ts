import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

// Auth0
import { AuthGuard, AuthModule } from '@auth0/auth0-angular';
import { AuthButtonComponent } from './auth-button/auth-button.component';

// HttpClient - external api
import { HttpClientModule } from '@angular/common/http';

// Forms
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';

// Components
import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FrontPageComponent } from './front-page/front-page.component';
import { ProfilePageComponent } from './profile-page/profile-page.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { TopicPageComponent } from './topic-page/topic-page.component';
import { ReplyPageComponent } from './reply-page/reply-page.component';
import { FavoritesPageComponent } from './favorites-page/favorites-page.component';
import { DogSearchComponent } from './dog-search/dog-search.component';
import { DogViewComponent } from './dog-view/dog-view.component';
import { AddProfileComponent } from './add-profile/add-profile.component';
import { AddtopicComponent } from './addtopic/addtopic.component';
import { ShelterSearchComponent } from './shelter-search/shelter-search.component';
import { ShelterviewPageComponent } from './shelterview-page/shelterview-page.component';
import { AddReplyComponent } from './add-reply/add-reply.component';
import { ProfileEmailComponent } from './profile-email/profile-email.component';
import { AddfavoriteButtonComponent } from './addfavorite-button/addfavorite-button.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';


@NgModule({
  declarations: [
    AppComponent,
    FrontPageComponent,
    ProfilePageComponent,
    AuthButtonComponent, 
    DogViewComponent,
    UserProfileComponent, 
    TopicPageComponent, 
    ReplyPageComponent, 
    FavoritesPageComponent,
    DogSearchComponent, 
    ShelterSearchComponent,
    NavbarComponent, 
    AddProfileComponent,
    AddtopicComponent,
    ShelterviewPageComponent,
    AddReplyComponent,
    AddfavoriteButtonComponent,
    ProfileEmailComponent,
    PageNotFoundComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: FrontPageComponent},
      { path: 'profile-page', component: ProfilePageComponent, canActivate:[AuthGuard]},
      { path: 'add-profile', component: AddProfileComponent, canActivate:[AuthGuard]},
      { path: 'topic-page', component: TopicPageComponent},
      { path: 'reply-page', component: ReplyPageComponent},
      { path: 'dogsearch-page', component: DogSearchComponent},
      { path: 'dogview-page', component: DogViewComponent},
      { path: 'addtopic', component: AddtopicComponent, canActivate:[AuthGuard]},
      { path: 'dogview-page/:id', component: DogViewComponent},
      { path: 'reply-page/:id', component: ReplyPageComponent},
      { path: 'favorites-page/:id', component: FavoritesPageComponent, canActivate:[AuthGuard]},
      { path: 'sheltersearch-page', component: ShelterSearchComponent},
      { path: 'shelterview-page/:id', component: ShelterviewPageComponent},
      { path: 'add-reply', component:AddReplyComponent,canActivate:[AuthGuard]},
      { path: '**', component:PageNotFoundComponent},
    ],
    { onSameUrlNavigation: 'reload' }),
    AuthModule.forRoot({
      domain: 'dev-tc6s9x9t.us.auth0.com',
      clientId: 'xRoxK7dHIK8DecyAzJsMlTfUEcLH9mdC'
    })
  ],

  bootstrap: [AppComponent],
})
export class AppModule {}

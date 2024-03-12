import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Main } from '../AngularModels/topic';
import { TopicsAPIService } from '../services/topics-api.service';

@Component({
  selector: 'app-topic-page',
  templateUrl: './topic-page.component.html',
  styleUrls: ['./topic-page.component.css']
})
export class TopicPageComponent implements OnInit {
  
  topics: Main = {
    $id: "",
    $values: []
  }

  profile: any = {
    profileId: 0,
    profileName: ""
  }

  profiles: any = []

  constructor(private topicApi:TopicsAPIService, private router:Router, public auth0:AuthService) { 
    this.topicApi.getAllTopics().subscribe(
      response => {
        this.topics = response
        this.getProfileName()
      }
    )
  }
  
  ngOnInit(): void {
  }

  getProfileName() {
    this.topics.$values.forEach(element => {
      this.topicApi.getProfileById(element.profileId).subscribe(resp => {
        element.profile = resp
      })
    });
  }
  
  addTopic()
  {
    this.router.navigateByUrl('addtopic');
  }

}

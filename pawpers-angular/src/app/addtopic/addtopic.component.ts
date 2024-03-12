import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Topic } from '../AngularModels/topic';
import { TopicsAPIService } from '../services/topics-api.service';

@Component({
  selector: 'app-addtopic',
  templateUrl: './addtopic.component.html',
  styleUrls: ['./addtopic.component.css']
})
export class AddtopicComponent implements OnInit {

  userEmail:any = ''
  displayMessage:string = "";

  topicGroup: FormGroup = new FormGroup({ 
    topicName: new FormControl("", Validators.required),
    topicBody: new FormControl("", Validators.required),
    profileId: new FormControl(""),
    categoryId: new FormControl("", Validators.required),
    postTimestamp: new FormControl("")
  });

  //gets for Form Validation
  get category() {return this.topicGroup.get("categoryId");}
  get topicName() {return this.topicGroup.get("topicName");}
  get topicBody() {return this.topicGroup.get("topicBody");}

  constructor(public auth:AuthService, private topicService:TopicsAPIService, private router:Router) { 
    this.auth.user$.subscribe((result) => {
      this.userEmail = result?.email;
    })
  }

  ngOnInit(): void {
  }

  addTopic(topicGroup:FormGroup)
  {
    if (this.topicGroup.valid) {
      let profileId = 0
      this.topicService.getProfileByEmail(this.userEmail).subscribe(response => {
      profileId = response.profileId

      let topic: any = {
        topicName: this.topicGroup.get("topicName")?.value,
        topicBody: this.topicGroup.get("topicBody")?.value,
        profileId: profileId,
        categoryId: this.topicGroup.get("categoryId")?.value,
      }
  
      this.topicService.addTopic(topic).subscribe(
          (response) => {
            this.router.navigateByUrl('/topic-page')
          }
        )
      })
    }
    else
    {
      this.displayMessage = "All required fields must be filled!";
    }
  
    
  }
}

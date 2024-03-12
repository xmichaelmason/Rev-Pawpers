import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Reply } from '../AngularModels/reply';
import { TopicsAPIService } from '../services/topics-api.service';

@Component({
  selector: 'app-add-reply',
  templateUrl: './add-reply.component.html',
  styleUrls: ['./add-reply.component.css']
})
export class AddReplyComponent implements OnInit {
  userEmail: any
  topicID: any
  profileID: any
  displayMessage: string = "";

  constructor(public auth: AuthService, private replyService: TopicsAPIService, private router: Router, private route: ActivatedRoute) {
    this.topicID = Number(this.route.snapshot.paramMap.get("id"))

    this.auth.user$.subscribe((result) => {
      this.userEmail = result?.email;

      this.replyService.getProfileByEmail(this.userEmail).subscribe(response => {
        this.profileID = response.profileId
      })
    })
  }

  replyGroup: FormGroup = new FormGroup({
    replyMessage: new FormControl("", Validators.required),
    topicId: new FormControl(""),
    profileId: new FormControl(""),
  });

  //gets for Form Validation
  get message() { return this.replyGroup.get("replyMessage"); }

  ngOnInit(): void {
    console.log(this.userEmail)
  }

  createReply(replyGroup: FormGroup) {
    if (this.replyGroup.valid) {

      let reply: Reply = {
        replyMessage: this.replyGroup.get("replyMessage")?.value,
        topicId: this.topicID,
        profileId: this.profileID,
      }

      this.replyService.createReply(reply).subscribe(
        (response) => {
          window.location.reload();
        }
      )

    }
    else {
      this.displayMessage = "Reply must not be empty!";
    }
  }
};
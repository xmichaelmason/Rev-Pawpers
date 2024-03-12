import { Component, Input, OnChanges, OnInit, SimpleChange, SimpleChanges } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '@auth0/auth0-angular';
import { Category } from '../AngularModels/Category';
import { Profile } from '../AngularModels/profile';
import { Main, Reply } from '../AngularModels/reply';
import { Topic } from '../AngularModels/topic';
import { TopicsAPIService } from '../services/topics-api.service';

@Component({
  selector: 'app-reply-page',
  templateUrl: './reply-page.component.html',
  styleUrls: ['./reply-page.component.css']
})
export class ReplyPageComponent implements OnInit {

  topic: any = {}

  show: boolean = false

  constructor(public auth0:AuthService, private topicApi: TopicsAPIService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit(): void {
    let topicId = Number(this.route.snapshot.paramMap.get("id"))
    this.getTopicWithReplies(topicId)
  }

  getTopicWithReplies(topicId: number) {
    this.topicApi.getTopicById(topicId).subscribe(response => {
      this.topic = response

      this.topicApi.getProfileById(this.topic.profileId).subscribe(response => {
        this.topic.profile = response

        this.topic.replies.$values.forEach((element: { profileId: number; profile: any; }) => {
          this.topicApi.getProfileById(element.profileId).subscribe(response => {
            element.profile = response
          })
        });
      })
    })
  }

  showOnClick() {
    this.show = !this.show
  }

  redirectToAddReply()
  {
    this.router.navigateByUrl('add-reply');
  }
  
}
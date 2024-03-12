import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Reply } from '../AngularModels/reply';
import { Topic } from '../AngularModels/topic';


@Injectable({
  providedIn: 'root'
})
export class TopicsAPIService {

  private endpoint:string = "https://pawpers.azurewebsites.net";
  
  constructor(private http:HttpClient) { }

  //This should list out all the Topics
  getAllTopics() {
    //httpclient get() method will do a get request
    return this.http.get<any>(this.endpoint + "/Topic/GetAllWithNav")
  }

  getTopicById(topicId: number) {
      return this.http.get<any>(this.endpoint + "/Topic/GetWithNav/" + topicId);
  }

  getRepliesByTopicId(topicId: number) {
    return this.http.get<any>(this.endpoint + "/Reply/SearchByTopic/" + topicId)
  }

  getProfileById(profileId: number) {
    return this.http.get<any>(this.endpoint + "/Profile/Get/" + profileId )
  }

  getProfileByEmail(email: string) {
    return this.http.get<any>(this.endpoint + "/Profile/GetEmail/" + email)
  }

  addTopic(topic:any)
  {
    return this.http.post(this.endpoint + "/Topic/Create", topic);
  }


  createReply(reply:Reply)
  {
    return this.http.post<Topic>(this.endpoint + "/Reply/Create", reply);
  }

}

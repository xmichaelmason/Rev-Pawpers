import { Component, Input, OnInit } from '@angular/core';
import emailjs, { EmailJSResponseStatus } from 'emailjs-com';

@Component({
  selector: 'app-profile-email',
  templateUrl: './profile-email.component.html',
  styleUrls: ['./profile-email.component.css']
})
export class ProfileEmailComponent implements OnInit {

  @Input() profile: any
  @Input() hasYard: any
  @Input() hasChildren: any
  @Input() dwellingType: any
  @Input() familyAllergies: any

  show:boolean = true

  constructor() {}

  public sendEmail(e: Event) {
    e.preventDefault();
    emailjs.sendForm('service_7k84kno', 'template_f9duu7q', e.target as HTMLFormElement, 'user_vBbqiTVSjVwFy8zwjAp6L')
      .then((result: EmailJSResponseStatus) => {
        console.log(result.text);
      }, (error) => {
        console.log(error.text);
      });

    this.show = !this.show
  }

  ngOnInit(): void {}
}

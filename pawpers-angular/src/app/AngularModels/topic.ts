import { Category } from "./Category";
import { Profile } from "./profile";
import { Reply } from "./reply";


export interface Main {
  $id:     string;
  $values: Topic[];
}

export interface Topic {
  topicId: number
  topicName: string
  topicBody: string
  profileId: number
  postTimestamp: any
  categoryId: number
  category: Category
  profile: Profile
  replies: Reply[]
}
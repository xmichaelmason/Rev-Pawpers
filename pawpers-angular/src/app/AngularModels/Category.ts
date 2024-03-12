import { Topic } from "./topic";

export interface Category {
    categoryId: number
    categoryName: string
    topics: Topic[]
  }
  
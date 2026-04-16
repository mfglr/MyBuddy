import { Post } from "./post";

export class PostMediaCountError extends Error{
  constructor(){
    super(`You can upload up to ${Post.maxMediaCount} media per post!`);
  }
}

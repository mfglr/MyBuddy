export class InvalidMediaTypeError extends Error{
  constructor(){
    super("Invalid media type.A media can be an image or video");
  }
}

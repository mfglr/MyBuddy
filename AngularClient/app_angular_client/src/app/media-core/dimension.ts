export class Dimension{
  width: number;
  height: number;

  constructor(width: number, height: number) {
    this.width = width;
    this.height = height;
  }

  aspectRatio(){
    return this.width / this.height;
  }
}

function addLoadEvent(func) {
  var oldonload = window.onload;
  if (typeof window.onload != 'function') {
    window.onload = func;
  } else {
    window.onload = function() {
      if (oldonload) {
        oldonload();
      }
      func();
    }
  }
}




var timer = 3;
// array of photo names
var photos = [
['1', 'Slide Show'],
['2', 'Slide Show'],
['3', 'Slide Show']
];
var img, count = 1;
function startSlideshow()
{
	img = document.getElementById('photo');
	window.setTimeout('cueNextSlide()', timer * 1000);
}
function cueNextSlide()
{
	var next = new Image();
	next.onerror = function()
	{
		alert('Failed to load next image');
	};
	next.onload = function()
	{
		img.src = next.src;
		img.alt = photos[count][1];
		
		if (++count == photos.length)
		{
			count = 0; 
		}
		window.setTimeout('cueNextSlide()', timer * 1000);
	};
	next.src = 'photos/' + photos[count][0] + '.jpg';
}
addLoadEvent(startSlideshow)
//addLoadListener(startSlideshow);
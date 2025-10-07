const LSGetCookie=(name:string)=> {
  // Add an equals sign to the name for easier comparison
  const cookieName = name + "=";
  // Get all cookies and decode them
  const decodedCookie = decodeURIComponent(document.cookie);
  // Split the cookie string into an array of individual cookies
  const cookieArray = decodedCookie.split(';');

  // Loop through the array to find the desired cookie
  for (let i = 0; i < cookieArray.length; i++) {
    let cookie = cookieArray[i] as string;
    // Trim leading whitespace
    while (cookie.charAt(0) === ' ') {
      cookie = cookie.substring(1);
    }
    // If the cookie starts with the desired name, extract and return its value
    if (cookie.indexOf(cookieName) === 0) {
      return cookie.substring(cookieName.length, cookie.length);
    }
  }
  // Return null if the cookie is not found
  return null;
}

// Example usage:
// document.cookie = "username=JohnDoe; expires=Thu, 18 Dec 2025 12:00:00 UTC; path=/";
// const username = getCookie("username");
// console.log(username); // Output: JohnDoe

export {LSGetCookie} ;
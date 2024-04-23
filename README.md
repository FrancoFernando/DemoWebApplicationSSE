# DemoWebApplicationSSE

Demo Web Application using Server-Sent Events (SSE)

 ### Event
> The Event interface represents an event which takes place in the DOM.     
> 
> -- <cite> https://developer.mozilla.org/en-US/docs/Web/API/Event </cite>

 ### Server-sent events
> Usually, a web page send a request to the server to receive new data. With server-sent events, it's possible for a server to send new data to a web page at any time, by pushing messages to the web page. These incoming messages can be treated as Events + data inside the web page.  
> 
> -- <cite> https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events </cite>

 ### Using server-sent events
> Developing a web application that uses server-sent events is straightforward. You'll need a bit of code on the server to stream events to the front-end, but the client side code works almost identically to websockets in part of handling incoming events. This is a one-way connection, so you can't send events from a client to a server.    
> 
> -- <cite> https://developer.mozilla.org/en-US/docs/Web/API/Server-sent_events/Using_server-sent_events </cite>


 ### EventSource
>The **EventSource** interface is web content's interface to server-sent events. An EventSource instance opens a persistent connection to an **HTTP** server, which sends events in `text/event-stream` format. The connection remains open until closed by calling `EventSource.close()`.
>
>Once the connection is opened, incoming messages from the server are delivered to your code in the form of events. If there is an event field in the incoming message, the triggered event is the same as the event field value. If no event field is present, then a generic message event is fired.
>
> --<cite> https://developer.mozilla.org/en-US/docs/Web/API/EventSource </cite>

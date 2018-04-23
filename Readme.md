# How to: Implement a Custom Geocode Provider


This example demonstrates how to create a custom Geocode provider.


<h3>Description</h3>

<p>To do this, design a class that inherits&nbsp;the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapInformationDataProviderBasetopic">InformationDataProviderBase</a>&nbsp;class and the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapIMouseClickRequestSendertopic">IMouseClickRequestSender</a>&nbsp;interface,&nbsp;and implement the&nbsp;<strong>CreateData</strong>&nbsp;and&nbsp;<br><strong>RequestByPoint</strong>&nbsp; methods in the class. Then, design a class that inherits the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapIInformationDatatopic">IInformationData</a>&nbsp;interface and override its&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapIInformationData_OnDataResponsetopic">OnDataResponse</a>&nbsp;event. Implement the&nbsp;<strong>CalculateAddress</strong>&nbsp;method to provide custom geocode&nbsp;logic.</p>

<br/>



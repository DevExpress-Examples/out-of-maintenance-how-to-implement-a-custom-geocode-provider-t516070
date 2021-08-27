<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128576509/16.1.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T516070)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/CustomGeocodeProvider/Form1.cs) (VB: [Form1.vb](./VB/CustomGeocodeProvider/Form1.vb))
<!-- default file list end -->
# How to: Implement a Custom Geocode Provider


This example demonstrates how to create a custom Geocode provider.


<h3>Description</h3>

<p>To do this, design a class that inherits&nbsp;the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapInformationDataProviderBasetopic">InformationDataProviderBase</a>&nbsp;class and the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapIMouseClickRequestSendertopic">IMouseClickRequestSender</a>&nbsp;interface,&nbsp;and implement the&nbsp;<strong>CreateData</strong>&nbsp;and&nbsp;<br><strong>RequestByPoint</strong>&nbsp; methods in the class. Then, design a class that inherits the&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/clsDevExpressXtraMapIInformationDatatopic">IInformationData</a>&nbsp;interface and override its&nbsp;<a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraMapIInformationData_OnDataResponsetopic">OnDataResponse</a>&nbsp;event. Implement the&nbsp;<strong>CalculateAddress</strong>&nbsp;method to provide custom geocode&nbsp;logic.</p>

<br/>



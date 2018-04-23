Imports DevExpress.XtraMap
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace CustomGeocodeProvider
    Partial Public Class Form1
        Inherits Form

        Private ReadOnly Property Layer() As InformationLayer
            Get
                Return CType(mapControl1.Layers(1), InformationLayer)
            End Get
        End Property
        Public Sub New()
            InitializeComponent()
            Layer.DataProvider = New GeocodeDataProvider()
        End Sub
    End Class
        Public Class GeocodeDataProvider
            Inherits InformationDataProviderBase
            Implements IMouseClickRequestSender

        Public Sub New()
            Me.ProcessMouseEvents = True
        End Sub
        Protected Shadows ReadOnly Property Data() As GeocodeData
            Get
                Return CType(MyBase.Data, GeocodeData)
            End Get
        End Property
        Protected Overrides Function CreateData() As IInformationData
            Return New GeocodeData()
        End Function
        Public Sub RequestByPoint(ByVal geoPoint As GeoPoint, ByVal screenPoint As MapPoint) Implements IMouseClickRequestSender.RequestByPoint

            Data.CalculateAddress(geoPoint)
        End Sub
    End Class
    Public Class GeocodeData
        Implements IInformationData


        Private address_Renamed As New LocationInformation()
        Public Property Address() As LocationInformation
            Get
                Return address_Renamed
            End Get
            Set(ByVal value As LocationInformation)
                address_Renamed = value
            End Set
        End Property

        Public Event OnDataResponse As EventHandler(Of RequestCompletedEventArgs) Implements IInformationData.OnDataResponse

        Private Function CreateEventArgs() As RequestCompletedEventArgs
            Dim item As MapItem = New MapCallout() With { _
                .Location = address_Renamed.Location, _
                .Text = address_Renamed.Address.FormattedAddress _
            }
            Return New RequestCompletedEventArgs(New MapItem() { item }, Nothing, False, Nothing)
        End Function
        Protected Sub RaiseChanged()
            RaiseEvent OnDataResponse(Me, CreateEventArgs())
        End Sub

        Public Sub CalculateAddress(ByVal geoPoint As GeoPoint)
            'Implement your custom geocode logic here
            Dim info As New LocationInformation()
            info.Address = New Address("Address from your service here " & Environment.NewLine & "Coordinates: " & geoPoint.ToString())
            info.Location = New GeoPoint(geoPoint.Latitude, geoPoint.Longitude)
            Address = info
            '
            RaiseChanged()
        End Sub
    End Class
    Public Class Address
        Inherits AddressBase

        Public Sub New(ByVal address As String)
            Me.FormattedAddress = address
        End Sub
    End Class
End Namespace

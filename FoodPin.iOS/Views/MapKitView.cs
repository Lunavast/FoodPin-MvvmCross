using System;
using CoreGraphics;
using CoreLocation;
using FoodPin.Core.Messenger;
using FoodPin.Core.ViewModels;
using MapKit;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.Plugins.Messenger;
using UIKit;

namespace FoodPin.iOS.Views
{
	public partial class MapKitView : MvxViewController
	{
		public new MapKitViewModel ViewModel
		{
			get { return (MapKitViewModel)base.ViewModel; }
			set { base.ViewModel = value; }
		}

		private MvxSubscriptionToken _token;
		public MapKitView() : base("MapKitView", null)
		{
		}

		void UpdateLocation(GeoCodingDoneMessage obj)
		{
			if (obj.Error)
				return;

			ConfigureAnnotation(obj.Lat, obj.Lng);

			MapView.ShowAnnotations(new IMKAnnotation[] { annotation }, true);
			MapView.SelectAnnotation(annotation, true);
		}

		BasicMapAnnotation annotation { get; set; }
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			_token = ViewModel.Messenger.Subscribe<GeoCodingDoneMessage>(UpdateLocation);
		}

		void ConfigureAnnotation(double lat, double lng)
		{
			MapView.Delegate = new MapDelegate(this);
			annotation = new BasicMapAnnotation(new CoreLocation.CLLocationCoordinate2D()
				{
					Latitude = lat,
					Longitude = lng,
				},
				ViewModel.Item.Name,
				ViewModel.Item.Type);
		}

		class BasicMapAnnotation : MKAnnotation
		{
			public CLLocationCoordinate2D coord;
			public string title, subtitle;

			public override CLLocationCoordinate2D Coordinate { get { return coord; } }
			public override void SetCoordinate(CLLocationCoordinate2D value)
			{
				coord = value;
			}
			public override string Title { get { return title; } }
			public override string Subtitle { get { return subtitle; } }
			public BasicMapAnnotation(CLLocationCoordinate2D coordinate, string title, string subtitle)
			{
				this.coord = coordinate;
				this.title = title;
				this.subtitle = subtitle;
			}
		}

		class MapDelegate : MKMapViewDelegate
		{
			protected string annotationIdentifier = "BasicAnnotation";
			MapKitView parent;

			public MapDelegate(MapKitView parent)
			{
				this.parent = parent;
			}

			public override MKAnnotationView GetViewForAnnotation(MKMapView mapView, IMKAnnotation annotation)
			{
				if (annotation is BasicMapAnnotation)
				{
					MKAnnotationView annotationView = mapView.DequeueReusableAnnotation(annotationIdentifier);
					if (annotationView == null)
						annotationView = new MKPinAnnotationView(annotation, annotationIdentifier);
					else
						annotationView.Annotation = annotation;

					annotationView.CanShowCallout = true;
					(annotationView as MKPinAnnotationView).PinTintColor = UIColor.Orange;

					var leftIconView = new UIImageView(new CGRect(0, 0, 53, 53));
					leftIconView.Image = UIImage.FromBundle(parent.ViewModel.Item.ImageName);
					annotationView.LeftCalloutAccessoryView = leftIconView;

					return annotationView;
				}
				return null;
			}
		}
	}
}


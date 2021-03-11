	
	var style = [
				  {
				    "featureType": "landscape",
				    "stylers": [
				      { "hue": "#ff0044" },
				      { "color": "#ecfe7d" }
				    ]
				  },{
				    "featureType": "water",
				    "stylers": [
				      { "color": "#f94880" }
				    ]
				  }
				]

	var styled_festival = new google.maps.StyledMapType(style, {name: "Festival style"});

	var festivalMapOptions = { 

		center: new google.maps.LatLng(54.722439, -0.252686),
		zoom: 6,
		mapTypeId: google.maps.MapTypeId.ROADMAP,
		maxZoom:12,
		minZoom:6,
		panControl: false,
		mapTypeControl: false,
	};


	var festivalMap;  // Stores the map
	google.maps.event.addDomListener(window, 'load', loadFestivalMap);  // calls loadMap on lao

	function setZoomWhenMarkerClicked(){

		var currentZoom = festivalMap.getZoom();
		 if (currentZoom < 7){
		 festivalMap.setZoom(7);
		 }
	}
	
	function createControlPanel (controlPanelDiv){
		 controlPanelDiv.style.padding = '0px';
		 controlUI = document.createElement('div');
		 controlUI.style.border='0px solid white';
		 controlUI.style.margin='10px';
		 controlUI.style.paddingTop='11px';
		 controlUI.style.paddingBottom='5px';
		 controlUI.style.paddingLeft='0px';
		 controlUI.style.paddingRight='0px';
		 controlUI.style.width='245px';
		 controlUI.style.height='419px';
		 controlPanelDiv.appendChild(controlUI);
		 //Map title
		 titleBar = document.createElement('div');
		 titleBar.style.backgroundColor = '#89CBED';
		 titleBar.style.height='255px';
		 titleBar.style.width='245px';
		 titleBar.style.marginTop='0px';
		 titleBar.style.marginBottom='0px';
		 titleBar.style.marginLeft='0px';
		 titleBar.style.marginRight='0px';
		 titleBar.style.paddingTop='6px';
		 titleBar.style.paddingBottom='2px';
		 titleBar.style.paddingLeft='0px';
		 titleBar.style.paddingRight='0px';
		 titleBar.style.borderTopLeftRadius='5px';
		 titleBar.style.borderTopRightRadius='5px';
		 titleBar.style.borderBottomLeftRadius='0px';
		 titleBar.style.borderBottomLeftRadius='0px';
		 titleBar.style.cssFloat='left';
		 titleBar.innerHTML = '<div align="center"><img src="./img/mapbox.png" width="230" height="252" border="0"/></div>';
		 controlUI.appendChild(titleBar);
		 yellowStripe = document.createElement('div');
		 yellowStripe.style.backgroundColor = '#FFFF00';
		 yellowStripe.style.height='2px';
		 yellowStripe.style.width='245px';
		 yellowStripe.style.marginTop='3px';
		 yellowStripe.style.marginBottom='3px';
		 yellowStripe.style.marginLeft='0px';
		 yellowStripe.style.marginRight='0px';
		 yellowStripe.style.paddingTop='0px';
		 yellowStripe.style.paddingBottom='0px';
		 yellowStripe.style.paddingLeft='0px';
		 yellowStripe.style.paddingRight='0px';
		 yellowStripe.style.cssFloat='left';
		 yellowStripe.style.fontFamily='Georgia, serif';
		 yellowStripe.style.fontSize='14px';
		 controlUI.appendChild(yellowStripe);
	}

	function loadFestivalMap() {
		
		festivalMap = new google.maps.Map(document.getElementById("mapcanvas"), festivalMapOptions);	

		festivalMap.mapTypes.set('map_styles_festival', styled_festival);
		festivalMap.setMapTypeId('map_styles_festival');

		// Add side images
		var controlPanelDiv = document.createElement('div');
		var festivalMapControlPanel = new createControlPanel(controlPanelDiv, festivalMap);
		festivalMap.controls[google.maps.ControlPosition.RIGHT_TOP].push(controlPanelDiv);

		loadMapMarkers();
	}

	function loadMapMarkers (){

		Reading();
		HydePark();
		Bestival();
		MagicSummer();
	}

	function HydePark()
	{
		var markerPositionHydePark = new google.maps.LatLng(51.507431, -0.165708); 		// Set map markers

		var markerIconHydePark = {
			url: './img/pin.png',
			size: new google.maps.Size(225, 120),
			origin: new google.maps.Point(0, 0), //The point on the image to measure the anchor from. 0, 0 is the top left.
			anchor: new google.maps.Point(25, 50) // The offset of the marker. 
		};

		// Used to deifne when the onClick handler gets triggered
		var markerShapeHydePark = {
		 coord: [12,4,216,22,212,74,157,70,184,111,125,67,6,56],
		 type: 'poly'
		};

		markerHydePark = new google.maps.Marker({
			position: markerPositionHydePark,
			 //adds the marker to the map.
			map: festivalMap,
			title: 'Hyde Park - Rolling Stones',
			 //assigns the icon image set above to the marker.
			icon: markerIconHydePark,
			 //assigns the icon shape set above to the marker.
			shape: markerShapeHydePark,
			 //sets the z-index of the map marker.
			zIndex:102
		});

		// Stylnig for pop-up
		var pop_up_info = "border: 0px solid black; background-color: #ffffff; padding:15px; margin-top: 8px; border-radius:10px; -moz-border-radius: 10px; -webkit-border-radius: 10px; box-shadow: 1px 1px #888;";

		// Creates the content for the pop-up
		var boxTextHydePark = document.createElement("div");
		boxTextHydePark.style.cssText = pop_up_info;
		boxTextHydePark.innerHTML = '<span class="pop_up_box_text"><img src="./img/hyde.jpg" width="400" height="285" border="0" /></span>';
		
		// InfoBox Config Options
		var infoboxOptionsHydePark = {
		 									content: boxTextHydePark,
		 									disableAutoPan: false,
		 									maxWidth: 0,
		 									pixelOffset: new google.maps.Size(-241, 0),
		 									zIndex: null,
		 									boxStyle: 
		 											{
		 												background: "url('./img/pop_up_box_top_arrow.png') no-repeat",
		 												opacity: 1,
		 												width: "430px"
		 											},
		 									closeBoxMargin: "10px 2px 2px 2px",
		 									closeBoxURL: "./img/button_close.png",
		 									infoBoxClearance: new google.maps.Size(1, 1),
		 									isHidden: false,
		 									pane: "floatPane",
		 									enableEventPropagation: false
		};


		infoboxHydePark = new InfoBox(infoboxOptionsHydePark);

		// Set on click listener
		google.maps.event.addListener(markerHydePark, "click", function (e) {

		 	infoboxHydePark.open(festivalMap, this);
		 	this.setZIndex(google.maps.Marker.MAX_ZINDEX + 1);

		 	setZoomWhenMarkerClicked();
		 	festivalMap.setCenter(markerHydePark.getPosition());
		});

	}

	function Bestival()
	{
		var markerPositionBestival = new google.maps.LatLng(50.692718, -1.316710); 		// Set map markers

		var markerIconBestival = {
			url: './img/pin.png',
			size: new google.maps.Size(225, 120),
			origin: new google.maps.Point(0, 0), //The point on the image to measure the anchor from. 0, 0 is the top left.
			anchor: new google.maps.Point(25, 50) // The offset of the marker. 
		};

		// Used to deifne when the onClick handler gets triggered
		var markerShapeBestival = {
		 coord: [12,4,216,22,212,74,157,70,184,111,125,67,6,56],
		 type: 'poly'
		};

		markerBestival = new google.maps.Marker({
			position: markerPositionBestival,
			 //adds the marker to the map.
			map: festivalMap,
			title: 'Bestival',
			 //assigns the icon image set above to the marker.
			icon: markerIconBestival,
			 //assigns the icon shape set above to the marker.
			shape: markerShapeBestival,
			 //sets the z-index of the map marker.
			zIndex:103
		});

		// Stylnig for pop-up
		var pop_up_info = "border: 0px solid black; background-color: #ffffff; padding:15px; margin-top: 8px; border-radius:10px; -moz-border-radius: 10px; -webkit-border-radius: 10px; box-shadow: 1px 1px #888;";

		// Creates the content for the pop-up
		var boxTextBestival = document.createElement("div");
		boxTextBestival.style.cssText = pop_up_info;
		boxTextBestival.innerHTML = '<span class="pop_up_box_text"><img src="./img/bestival.jpg" width="400" height="285" border="0" /></span>';
		
		// InfoBox Config Options
		var infoboxOptionsBestival = {
		 									content: boxTextBestival,
		 									disableAutoPan: false,
		 									maxWidth: 0,
		 									pixelOffset: new google.maps.Size(-241, 0),
		 									zIndex: null,
		 									boxStyle: 
		 											{
		 												background: "url('./img/pop_up_box_top_arrow.png') no-repeat",
		 												opacity: 1,
		 												width: "430px"
		 											},
		 									closeBoxMargin: "10px 2px 2px 2px",
		 									closeBoxURL: "./img/button_close.png",
		 									infoBoxClearance: new google.maps.Size(1, 1),
		 									isHidden: false,
		 									pane: "floatPane",
		 									enableEventPropagation: false
		};


		infoboxBestival = new InfoBox(infoboxOptionsBestival);

		// Set on click listener
		google.maps.event.addListener(markerBestival, "click", function (e) {

		 	infoboxBestival.open(festivalMap, this);
		 	this.setZIndex(google.maps.Marker.MAX_ZINDEX + 1);

		 	setZoomWhenMarkerClicked();
		 	festivalMap.setCenter(markerBestival.getPosition());
		});

	}

	function MagicSummer()
	{
		var markerPositionMagicSummer = new google.maps.LatLng(51.236220, -0.570409); 		// Set map markers

		var markerIconMagicSummer = {
			url: './img/pin.png',
			size: new google.maps.Size(225, 120),
			origin: new google.maps.Point(0, 0), //The point on the image to measure the anchor from. 0, 0 is the top left.
			anchor: new google.maps.Point(25, 50) // The offset of the marker. 
		};

		// Used to deifne when the onClick handler gets triggered
		var markerShapeMagicSummer = {
		 coord: [12,4,216,22,212,74,157,70,184,111,125,67,6,56],
		 type: 'poly'
		};

		markerMagicSummer = new google.maps.Marker({
			position: markerPositionMagicSummer,
			 //adds the marker to the map.
			map: festivalMap,
			title: 'Magic Summer',
			 //assigns the icon image set above to the marker.
			icon: markerIconMagicSummer,
			 //assigns the icon shape set above to the marker.
			shape: markerShapeMagicSummer,
			 //sets the z-index of the map marker.
			zIndex:104
		});

		// Stylnig for pop-up
		var pop_up_info = "border: 0px solid black; background-color: #ffffff; padding:15px; margin-top: 8px; border-radius:10px; -moz-border-radius: 10px; -webkit-border-radius: 10px; box-shadow: 1px 1px #888;";

		// Creates the content for the pop-up
		var boxTextMagicSummer = document.createElement("div");
		boxTextMagicSummer.style.cssText = pop_up_info;
		boxTextMagicSummer.innerHTML = '<span class="pop_up_box_text"><img src="./img/magic.jpg" width="400" height="285" border="0" /></span>';
		
		// InfoBox Config Options
		var infoboxOptionsMagicSummer = {
		 									content: boxTextMagicSummer,
		 									disableAutoPan: false,
		 									maxWidth: 0,
		 									pixelOffset: new google.maps.Size(-241, 0),
		 									zIndex: null,
		 									boxStyle: 
		 											{
		 												background: "url('./img/pop_up_box_top_arrow.png') no-repeat",
		 												opacity: 1,
		 												width: "430px"
		 											},
		 									closeBoxMargin: "10px 2px 2px 2px",
		 									closeBoxURL: "./img/button_close.png",
		 									infoBoxClearance: new google.maps.Size(1, 1),
		 									isHidden: false,
		 									pane: "floatPane",
		 									enableEventPropagation: false
		};


		infoboxMagicSummer = new InfoBox(infoboxOptionsMagicSummer);

		// Set on click listener
		google.maps.event.addListener(markerMagicSummer, "click", function (e) {

		 	infoboxMagicSummer.open(festivalMap, this);
		 	this.setZIndex(google.maps.Marker.MAX_ZINDEX + 1);

		 	setZoomWhenMarkerClicked();
		 	festivalMap.setCenter(markerMagicSummer.getPosition());
		});

	}

	function Reading()
	{
		var markerPositionGlastonbury = new google.maps.LatLng(51.452884, -0.973906); 		// Set map markers

		var markerIconGlastonbury = {
			url: './img/pin.png',
			size: new google.maps.Size(225, 120),
			origin: new google.maps.Point(0, 0), //The point on the image to measure the anchor from. 0, 0 is the top left.
			anchor: new google.maps.Point(25, 50) // The offset of the marker. 
		};

		// Used to deifne when the onClick handler gets triggered
		var markerShapeGlastonbury = {
		 coord: [12,4,216,22,212,74,157,70,184,111,125,67,6,56],
		 type: 'poly'
		};

		markerGlastonbury = new google.maps.Marker({
			position: markerPositionGlastonbury,
			 //adds the marker to the map.
			map: festivalMap,
			title: 'Reading',
			 //assigns the icon image set above to the marker.
			icon: markerIconGlastonbury,
			 //assigns the icon shape set above to the marker.
			shape: markerShapeGlastonbury,
			 //sets the z-index of the map marker.
			zIndex:102
		});

		// Stylnig for pop-up
		var pop_up_info = "border: 0px solid black; background-color: #ffffff; padding:15px; margin-top: 8px; border-radius:10px; -moz-border-radius: 10px; -webkit-border-radius: 10px; box-shadow: 1px 1px #888;";

		// Creates the content for the pop-up
		var boxTextGlastonbury = document.createElement("div");
		boxTextGlastonbury.style.cssText = pop_up_info;
		boxTextGlastonbury.innerHTML = '<span class="pop_up_box_text"><img src="./img/reading.jpg" width="400" height="285" border="0" /></span>';
		
		// InfoBox Config Options
		var infoboxOptionsGlastonbury = {
		 									content: boxTextGlastonbury,
		 									disableAutoPan: false,
		 									maxWidth: 0,
		 									pixelOffset: new google.maps.Size(-241, 0),
		 									zIndex: null,
		 									boxStyle: 
		 											{
		 												background: "url('./img/pop_up_box_top_arrow.png') no-repeat",
		 												opacity: 1,
		 												width: "430px"
		 											},
		 									closeBoxMargin: "10px 2px 2px 2px",
		 									closeBoxURL: "./img/button_close.png",
		 									infoBoxClearance: new google.maps.Size(1, 1),
		 									isHidden: false,
		 									pane: "floatPane",
		 									enableEventPropagation: false
		};


		infoboxGlastonbury = new InfoBox(infoboxOptionsGlastonbury);

		// Set on click listener
		google.maps.event.addListener(markerGlastonbury, "click", function (e) {

		 	infoboxGlastonbury.open(festivalMap, this);
		 	this.setZIndex(google.maps.Marker.MAX_ZINDEX + 1);

		 	setZoomWhenMarkerClicked();
		 	festivalMap.setCenter(markerGlastonbury.getPosition());
		});

	}
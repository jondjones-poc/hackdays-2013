<%@ Page language="c#" Inherits="Jondjones.com.Example.SearchResultsPage" Codebehind="SearchResultsPage.aspx.cs" %>


<script type="text/javascript" src="https://www.google.com/jsapi"></script>
       <script src="http://code.jquery.com/jquery.js"></script>

<script>
 
    var urlParams;
    (window.onpopstate = function () {
        var match,
            pl = /\+/g,  // Regex for replacing addition symbol with a space
            search = /([^&=]+)=?([^&]*)/g,
            decode = function (s) { return decodeURIComponent(s.replace(pl, " ")); },
            query = window.location.search.substring(1);

        urlParams = {};
        while (match = search.exec(query))
            urlParams[decode(match[1])] = decode(match[2]);
    })();
    
    $(document).ready(function () {
        $('#<%= searchText.ClientID %>').focus(function () {
                    $('#<%= searchText.ClientID %>').val('');
            });
            });
    
    (function () {
      
        google.load('search', '1', { language: 'en', "nocss": true });

        var settings = {
            searchField: '<%= searchText.ClientID %>',
            cx: '005600452745752080635:ylusvqhaprg',
            autoCompletionOptions: {
                'maxCompletions': 3,
                'styleOptions': {
                    'xOffset': 10
                }
                
            }
        };
        


        google.setOnLoadCallback(function () {
            
            customSearchControl = new google.search.CustomSearchControl(settings.cx);
            customSearchControl.setResultSetSize(google.search.Search.LARGE_RESULTSET);
            customSearchControl.setSearchCompleteCallback(window, methods.onSearchComplete, this);
            customSearchControl.setLinkTarget(google.search.Search.LINK_TARGET_SELF);
 
            google.search.CustomSearchControl.attachAutoCompletionWithOptions(settings.cx, settings.searchField, { 'submit': methods.triggerPostback }, settings.autoCompletionOptions);

            var options = new google.search.DrawOptions();
            options.setAutoComplete(true);
            options.enableSearchResultsOnly(true);
            customSearchControl.draw('cse', options);

            var queryFromUrl = methods.parseQueryFromUrl();
            
            if (queryFromUrl) {
                customSearchControl.execute(queryFromUrl);
            }

        }, true);

        var methods = {

            parseQueryFromUrl : function() {
                var queryParamName = "q";
                var search = window.location.search.substr(1);
                var parts = search.split('&');
                for (var i = 0; i < parts.length; i++) {
                    var keyvaluepair = parts[i].split('=');
                    if (decodeURIComponent(keyvaluepair[0]) == queryParamName) {
                        return decodeURIComponent(keyvaluepair[1].replace(/\+/g, ' '));
                    }
                }
                return '';
            },

            onSearchComplete: function (search) {
         
                $('#<%= searchText.ClientID %>').val(urlParams["q"]);
   
            },

            triggerPostback: function () {

                window.location = $('#<%= SubmitButton.ClientID %>').attr('href');

            }
        };
    })();
    


    
    
</script>


    <section class="wrapper">

        <div class="searchNav">
            <ul>
                <asp:TextBox runat="server" ID="searchText"  ValidationGroup="SearchResults"  />
                <asp:RequiredFieldValidator runat="server" ID="rfvSearch" ControlToValidate="searchText" ValidationGroup="SearchResults" />
                <asp:LinkButton runat="server" OnClick="PostbackResults" ID="SubmitButton" ValidationGroup="SearchResults"  CssClass="btn" Height="48"/>
            </ul>
  

        </div>


        <div id="cse">
            
            Loading...

        </div>
   
     </section>
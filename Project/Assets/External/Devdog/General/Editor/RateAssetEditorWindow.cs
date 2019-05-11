//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.IO;
//using System.Net;
//using Devdog.General.ThirdParty.UniLinq;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.Assertions;

//namespace Devdog.General.Editors
//{
//    public class RateAssetEditorWindow : EditorWindow
//    {
//        private static ProductLookup[] _installedProductNames = new ProductLookup[0];
//        private static int _drawFullIconCount = 3;
//        private static bool _isHoveringVotingIcons = false;
//        private static ProductLookup _requestingFeedbackOnProduct;
//        private static ProductLookup _requestMailSignupForProduct;
//        private static bool _forceShowVotingPage = false;

//        private const string IconRootPath = "Assets/Devdog/General/EditorStyles/";
//        private const string ReviewIconUri = IconRootPath + "Star.png";
//        private const string ReviewIconEmptyUri = IconRootPath + "StarEmpty.png";
//        private const string VotingThankYouScreenUri = IconRootPath + "VotingThankYouScreen.png";
//        protected static Texture reviewIcon;
//        protected static Texture reviewIconEmpty;
//        protected static Texture votingThankYouScreen;

//        [MenuItem("Tools/Devdog/Rate Assets")]
//        public static void ShowWindow()
//        {
//            var window = GetWindow<RateAssetEditorWindow>();
//            window.minSize = new Vector2(460f, 260f);
//            window.maxSize = window.minSize;
//            window.titleContent = new GUIContent("Rate Devdog Assets");
//            window.wantsMouseMove = true;
//            window.ShowUtility();
//        }

//        [UnityEditor.Callbacks.DidReloadScripts]
//        protected static void ScriptReload()
//        {
//            Initialize();
//        }

//        private static void Initialize()
//        {
//            reviewIcon = AssetDatabase.LoadAssetAtPath<Texture>(ReviewIconUri);
//            reviewIconEmpty = AssetDatabase.LoadAssetAtPath<Texture>(ReviewIconEmptyUri);
//            votingThankYouScreen = AssetDatabase.LoadAssetAtPath<Texture>(VotingThankYouScreenUri);
//            _forceShowVotingPage = false;
//            _requestMailSignupForProduct = null;
//            _requestingFeedbackOnProduct = null;
//            _triedToSubmit = false;

//            _installedProductNames = ProductRatingUtility.GetAllProducts();
//        }

//        protected void OnEnable()
//        {
//            Initialize();
//        }

//        protected void Update()
//        {
//            Repaint();
//        }

//        protected void OnGUI()
//        {
//            if (_isHoveringVotingIcons == false)
//            {
//                var time = (EditorApplication.timeSinceStartup % 5);
//                _drawFullIconCount = (int)(time * 2f);
//            }

//            int nonVotedCount = _installedProductNames.Count(o => o.hasReview == false);
//            if (nonVotedCount == 0 && _requestingFeedbackOnProduct == null && _forceShowVotingPage == false)
//            {
//                DrawThankYouScreen();
//            }
//            else
//            {
//                if (_requestingFeedbackOnProduct != null)
//                {
//                    DrawFeedbackRequestForProduct(_requestingFeedbackOnProduct);
//                }
//                else if (_requestMailSignupForProduct != null)
//                {
//                    DrawMailSignupRequestForProduct(_requestMailSignupForProduct);
//                }
//                else
//                {
//                    DrawVotingToolsForAllNonVotedAssets();
//                }
//            }
//        }

//        private static bool _triedToSubmit = false;
//        private static bool _subscribeToNewsletter = true;
//        private void DrawFeedbackRequestForProduct(ProductLookup product)
//        {
//            EditorGUI.LabelField(new Rect(10, 10, position.width - 20f, 20), "Leave feedback for " + product.name + " (your rating: " + product.rating + "/5)");
//            EditorGUI.LabelField(new Rect(10, 30, position.width - 20f, 20), "Email:");

//            if (_triedToSubmit && string.IsNullOrEmpty(product.email))
//            {
//                GUI.color = Color.red;
//            }

//            product.email = EditorGUI.TextField(new Rect(10, 50, position.width - 20f, EditorGUIUtility.singleLineHeight), product.email);
//            GUI.color = Color.white;

//            EditorGUI.LabelField(new Rect(10, 70, position.width - 20f, 20), "Message:");
//            product.feedback = EditorGUI.TextArea(new Rect(10, 90, position.width - 20f, 40), product.feedback);

//            _subscribeToNewsletter = EditorGUI.Toggle(new Rect(position.width - 173f, 135f, 163f, EditorGUIUtility.singleLineHeight), "Subscribe to newsletter", _subscribeToNewsletter);

//            var btnRect = new Rect(10f, 135f, 100f, EditorGUIUtility.singleLineHeight);
//            if (GUI.Button(btnRect, "Cancel"))
//            {
//                _requestingFeedbackOnProduct = null;
//            }

//            btnRect.x += 110f;
//            if (GUI.Button(btnRect, "Submit"))
//            {
//                _triedToSubmit = true;
//                if (string.IsNullOrEmpty(product.email) == false)
//                {
//                    _requestingFeedbackOnProduct = null;
//                    _requestMailSignupForProduct = null;
//                    _forceShowVotingPage = false;
                    
//                    // Send data
//                    ProductRatingUtility.SubmitProduct(product);

//                    if (_subscribeToNewsletter)
//                    {
//                        string result;
//                        NewsletterEditorUtility.SubscribeToMailingList(product.email, out result);
//                    }
//                }
//            }
//        }

//        private void DrawMailSignupRequestForProduct(ProductLookup product)
//        {
//            EditorGUI.LabelField(new Rect(10, 10, position.width - 20f, 40f), "Subscribe to the newsletter for new product\nannouncements, discounts, giveaways and more.");
//            EditorGUI.LabelField(new Rect(10, 50, position.width - 20f, 20), "Email:");
//            if (_triedToSubmit && string.IsNullOrEmpty(product.email))
//            {
//                GUI.color = Color.red;
//            }

//            product.email = EditorGUI.TextField(new Rect(10, 70, position.width - 20f, EditorGUIUtility.singleLineHeight), product.email);
//            GUI.color = Color.white;

//            var btnRect = new Rect(10f, 100f, 100f, EditorGUIUtility.singleLineHeight);
//            if (GUI.Button(btnRect, "No thank you"))
//            {
//                _requestingFeedbackOnProduct = null;
//                _requestMailSignupForProduct = null;
//            }

//            btnRect.x += 110f;
//            if (GUI.Button(btnRect, "Subscribe"))
//            {
//                _triedToSubmit = true;
//                if (string.IsNullOrEmpty(product.email) == false)
//                {
//                    _requestingFeedbackOnProduct = null;
//                    _requestMailSignupForProduct = null;
//                    _forceShowVotingPage = false;

//                    if (_subscribeToNewsletter)
//                    {
//                        string result;
//                        NewsletterEditorUtility.SubscribeToMailingList(product.email, out result);
//                    }
//                }
//            }
//        }

//        private void DrawVotingToolsForAllNonVotedAssets()
//        {
//            const int iconSize = 32;
//            const int iconMargin = 5;

//            const int rowHeight = 36;
//            const int labelWidth = 160;

//            int productIndex = -1;
//            foreach (var product in _installedProductNames)
//            {
//                productIndex++;

//                int hoverCount = 0;
//                using (new GroupBlock(new Rect(10, productIndex * rowHeight, position.width, rowHeight)))
//                {
//                    EditorGUI.LabelField(new Rect(0, (rowHeight - EditorGUIUtility.singleLineHeight) / 2 + 4, labelWidth, rowHeight), product.niceName);

//                    var prodRating = product.rating;
//                    if (prodRating.HasValue)
//                    {
//                        GUI.color = new Color(1f, 1f, 1f, 0.5f);
//                    }

//                    for (int i = 0; i < 5; i++)
//                    {
//                        Rect r = new Rect(labelWidth + i * iconSize, iconMargin, iconSize, iconSize);
//                        if ((prodRating.HasValue && i < prodRating.Value) || (prodRating.HasValue == false && i < _drawFullIconCount))
//                        {
//                            GUI.DrawTexture(r, reviewIcon);
//                        }
//                        else
//                        {
//                            GUI.DrawTexture(r, reviewIconEmpty);
//                        }

//                        EditorGUIUtility.AddCursorRect(r, MouseCursor.Link);
//                        if (r.Contains(Event.current.mousePosition))
//                        {
//                            hoverCount++;
//                            _drawFullIconCount = i + 1;

//                            if (Event.current.type == EventType.MouseDown)
//                            {
//                                RateProduct(product, i + 1); // +1 because loop is 0 based
//                            }
//                        }

//                        r.x += iconSize;
//                    }

//                    GUI.color = Color.white;
//                }

//                _isHoveringVotingIcons = hoverCount > 0;
//            }
//        }

//        private void RateProduct(ProductLookup product, int rating)
//        {
//            _triedToSubmit = false;
//            product.rating = rating;
//            if (rating <= 3)
//            {
//                // Request feedback
//                _requestingFeedbackOnProduct = product;
//            }
//            else
//            {
//                // Open asset store so the user can leave the review
//                _requestMailSignupForProduct = product;
//                OpenProductPage(product);
//            }
//        }

//        private void OpenProductPage(ProductLookup product)
//        {
//            // TODO: Make dynamic (use XML config files in root of product)
//            string path = "";
//            switch (product.name)
//            {
//                case "InventoryPro":
//                    path = "content/66801";
//                    break;
//                case "QuestSystemPro":
//                    path = "content/63460";
//                    break;
//                case "SciFiDesign":
//                    path = "content/55270";
//                    break;
//                case "LosPro":
//                    path = "content/55292";
//                    break;
//                default:
//                    break;
//            }

//            if (string.IsNullOrEmpty(path) == false)
//            {
//                UnityEditorInternal.AssetStore.Open(path);
//            }
//        }

//        private void DrawThankYouScreen()
//        {
//            GUI.DrawTexture(new Rect(Vector2.zero, position.size), votingThankYouScreen);
//            if(GUI.Button(new Rect(position.width - 160f, position.height - 24f, 154f, EditorGUIUtility.singleLineHeight), "Back to rating screen"))
//            {
//                _forceShowVotingPage = true;
//            }
//        }
//    }
//}

//using System;
//using UnityEngine;
//using UnityEditor;

//namespace Devdog.General.Editors.GameRules
//{
//    public class UnratedAssetsRule : GameRuleBase
//    {
//        public override void UpdateIssue()
//        {
//            var unrated = ProductRatingUtility.GetAllUnratedProducts();
//            foreach (var prod in unrated)
//            {
//                var p = prod;
//                issues.Add(new GameRuleIssue("You have not rated " + p.niceName + " yet.", MessageType.Info, new GameRuleAction("Fix (Leave rating)",
//                    () =>
//                    {
//                        RateAssetEditorWindow.ShowWindow();
//                    })));
//            }
//        }
//    }
//}
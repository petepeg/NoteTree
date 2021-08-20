using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using NoteTree.Models;

namespace NoteTreeTests
{
    [TestClass]
    public class DocNodeInitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int dummyId = 1;

            var docNode = new DocNode(dummyId, null)
            {
                Id = dummyId,
                Title = "New Node",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now
            };
            
            var document = new Document
            {
                Id = dummyId,
                Title = "New Document",
                DateCreated = DateTime.Now,
                DateModified = DateTime.Now,
                NodeList = new List<DocNode>{docNode}
        };

            Assert.AreEqual("New Document", document.Title, true, "document Title was not Initalized");
            Assert.IsInstanceOfType(document.DateCreated, typeof(DateTime), "document DateCreated was not of type DateTime");
            Assert.IsInstanceOfType(document.DateModified, typeof(DateTime), "document DateModified was not of type DateTime");
            Assert.AreEqual(1, document.NodeList.Count, "NodeList not initalized");

            Assert.AreEqual("New Node", docNode.Title, "docNode Title was not Initalized");
            Assert.AreEqual(dummyId, docNode.DocumentId, "docNode DocumentId not Initaliized");
            Assert.IsNull(docNode.ParentNodeId, "ParentNodeId not Initalized");
            Assert.AreEqual(dummyId, docNode.Id, "docNode Id not Initaliized");
            Assert.IsInstanceOfType(docNode.DateCreated, typeof(DateTime), "docNode DateCreated was not of type DateTime");
            Assert.IsInstanceOfType(docNode.DateModified, typeof(DateTime), "docNode DateModified was not of type DateTime");



        }
    }
}
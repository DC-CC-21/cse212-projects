using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add "A" (1), "B" (1), and "C" (1) to the queue
    // Expected Result: "A", "B", "C"
    // Defect(s) Found: Dequeue was missing a .removeAt method to remove the item from the queue
    public void TestPriorityQueue_1()
    {
        //Check that the Enqueue method adds items to the queue in the right order

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 1);
        priorityQueue.Enqueue("C", 1);
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Create a queue with the following values: A (1), B (3), C (2), D (3), E (1)
    // Expected Result: "B", "D", "C", "A", "E"
    // Defect(s) Found:  None
    public void TestPriorityQueue_2()
    {
        // Check that the Dequeue method removes the eqrliest found highest priority item from the queue
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 2);
        priorityQueue.Enqueue("D", 3);
        priorityQueue.Enqueue("E", 1);

        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("D", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("E", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Create a queue with the following values: A (1), B (3), C (3), C (2)
    // Expected Result: "B"
    // Defect(s) Found: Removed equals sign in dequeue comparison to not overwrite the earliest found item if the priority is the same
    public void TestPriorityQueue_3()
    {
        // Check that the Dequeue method removes the eqrliest found highest priority item from the queue
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 3);
        priorityQueue.Enqueue("D", 2);

        Assert.AreEqual("B", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue twice from a queue with only one value
    // Expected Result: "The queue is empty."
    // Defect(s) Found: None
    public void TestPriorityQueue_4()
    {
        // Check that the Dequeue method throws an exception when trying to remove data from an empty queue

        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);

        try
        {
            priorityQueue.Dequeue();
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
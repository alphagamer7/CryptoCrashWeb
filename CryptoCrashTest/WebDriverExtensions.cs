
using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;


namespace CryptoCrashTest
{
    public static class WebDriverExtensions
    {
        /// <summary>
        /// Same as FindElement only returns null when not found instead of an exception.
        /// </summary>
        /// <param name="driver">current browser instance</param>
        /// <param name="by">The search string for finding element</param>
        /// <returns>Returns element or null if not found</returns>
        public static IWebElement FindElementSafe(this ISearchContext driver, By by)
        {
            try
            {
                return driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        /// <summary>
        /// Requires finding element by FindElementSafe(By).
        /// Returns T/F depending on if element is defined or null.
        /// </summary>
        /// <param name="element">Current element</param>
        /// <returns>Returns T/F depending on if element is defined or null.</returns>
        public static bool Exists(this IWebElement element)
        {
            if (element == null)
            {
                return false;
            }
            return true;
        }

        public static IWebElement FindElementWaitSafe(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    var isFound = wait.Until(drv =>
                    {
                        try
                        {
                            return drv.FindElement(by).Displayed;
                        }
                        catch (StaleElementReferenceException)
                        {
                            return false;
                        }
                        catch (NoSuchElementException)
                        {
                            return false;
                        }
                    });
                }
                return driver.FindElementSafe(by);
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }

        public static ReadOnlyCollection<IWebElement> FindElementsWaitSafe(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            try
            {
                if (timeoutInSeconds > 0)
                {
                    var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                    var isFound = wait.Until(drv =>
                    {
                        try
                        {
                            return drv.FindElements(by).Count > 0;
                        }
                        catch (StaleElementReferenceException)
                        {
                            return false;
                        }
                        catch (NoSuchElementException)
                        {
                            return false;
                        }
                    });
                }
                // FindElements() is always SAFE because it return Empty List when NOT found any element.
                return driver.FindElements(by);
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }
    }
}


